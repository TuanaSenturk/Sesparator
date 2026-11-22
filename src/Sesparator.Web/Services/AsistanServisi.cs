using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Sesparator.Web.Data;
using Sesparator.Web.Helpers;
using Sesparator.Web.Models;
using Sesparator.Web.Models.Api;

namespace Sesparator.Web.Services;

public class AsistanServisi
{
    private static readonly CultureInfo Tr = new("tr-TR");

    // Onay bekleyen bir işlem varken bu kelimeler Gemini'ye gitmeden yakalanır
    private static readonly HashSet<string> OnayKelimeleri = ["evet", "onaylıyorum", "onayla", "tamam"];
    private static readonly HashSet<string> IptalKelimeleri = ["vazgeç", "iptal", "hayır"];

    // Uzun cümleler onay/iptal cevabı sayılmaz, yeni komut olarak Gemini'ye gider
    private const int OnayCevabiEnFazlaKelime = 5;

    // IslemBilgisi alanındaki Türkçe karakterler ç gibi kaçışlarla yazılmasın
    private static readonly JsonSerializerOptions JsonAyarlari = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    };

    private readonly INiyetServisi _niyetServisi;
    private readonly BankaIslemServisi _banka;
    private readonly UygulamaDbContext _db;

    public AsistanServisi(INiyetServisi niyetServisi, BankaIslemServisi banka, UygulamaDbContext db)
    {
        _niyetServisi = niyetServisi;
        _banka = banka;
        _db = db;
    }

    public async Task<AsistanYaniti> MesajIsleAsync(string kullaniciId, string metin)
    {
        var (yanit, islemBilgisi) = await YanitUretAsync(kullaniciId, metin);
        await LogYazAsync(kullaniciId, metin, yanit.Niyet, islemBilgisi, yanit.Mesaj);
        return yanit;
    }

    // Gemini hata verdiğinde de konuşma kaydedilir (yönetici panelindeki anlaşılamayan komutlar için)
    public Task HataLogYazAsync(string kullaniciId, string metin, string hata) =>
        LogYazAsync(kullaniciId, metin, null, null, hata);

    private async Task<(AsistanYaniti Yanit, string? IslemBilgisi)> YanitUretAsync(string kullaniciId, string metin)
    {
        // 1) Onay bekleyen bir transfer varsa "evet" / "vazgeç" cevabını burada yakala
        var bekleyen = await _banka.BekleyenSesliIslemAsync(kullaniciId);
        if (bekleyen is not null)
        {
            var cevap = OnayCevabiMi(metin);
            var bilgi = JsonSerializer.Serialize(
                new { IslemId = bekleyen.Id, bekleyen.Tutar, bekleyen.AliciIban }, JsonAyarlari);

            if (cevap == Niyetler.Onay)
            {
                var sonuc = await _banka.TransferGerceklestirAsync(kullaniciId, bekleyen.Id);
                return (new AsistanYaniti { Niyet = Niyetler.Onay, Mesaj = sonuc.Mesaj, IslemId = bekleyen.Id }, bilgi);
            }

            if (cevap == Niyetler.Iptal)
            {
                await _banka.BekleyenIslemIptalEtAsync(kullaniciId, bekleyen.Id);
                return (new AsistanYaniti { Niyet = Niyetler.Iptal, Mesaj = "İşlem iptal edildi.", IslemId = bekleyen.Id }, bilgi);
            }
            // Onay/iptal değilse normal akışa devam: yeni bir komut olabilir
        }

        // 2) Normal akış: Gemini ile niyet çıkarma
        var alicilar = await _banka.AlicilarAsync(kullaniciId);
        var niyet = await _niyetServisi.NiyetCikarAsync(metin, alicilar.Select(a => a.TakmaAd).ToList());
        var niyetBilgisi = JsonSerializer.Serialize(niyet, JsonAyarlari);

        switch (niyet.Niyet)
        {
            case Niyetler.BakiyeSorgula:
            {
                var hesaplar = await _banka.HesaplarAsync(kullaniciId);
                var mesaj = hesaplar.Count == 0
                    ? "Size ait bir hesap bulunamadı."
                    : string.Join(", ", hesaplar.Select(h =>
                          $"{Bicim.HesapTuruAdi(h.HesapTuru)} hesabınızda {Bicim.Para(h.Bakiye, h.ParaBirimi)}")) + " bulunuyor.";
                return (new AsistanYaniti { Niyet = niyet.Niyet, Mesaj = mesaj }, niyetBilgisi);
            }

            case Niyetler.ParaTransferi:
            {
                var kontrol = await _banka.TransferKontrolEtAsync(kullaniciId, niyet.Tutar, niyet.AliciTakmaAd, alicilar);
                if (!kontrol.Basarili)
                    return (new AsistanYaniti { Niyet = niyet.Niyet, Mesaj = kontrol.Mesaj }, niyetBilgisi);

                var t = kontrol.Transfer!;
                var islemId = await _banka.BekleyenTransferKaydetAsync(kullaniciId, t);
                return (new AsistanYaniti
                {
                    Niyet = niyet.Niyet,
                    OnayGerekli = true,
                    BekleyenTransfer = t,
                    IslemId = islemId,
                    Mesaj = $"{t.AliciAdSoyad} kişisine {Bicim.Para(t.Tutar)} gönderilecek. Onaylıyor musunuz?"
                }, niyetBilgisi);
            }

            default:
                return (new AsistanYaniti
                {
                    Niyet = Niyetler.Bilinmiyor,
                    Mesaj = "Bunu anlayamadım. Bakiyenizi sorabilir ya da kayıtlı alıcılarınıza para gönderebilirsiniz."
                }, niyetBilgisi);
        }
    }

    // "Evet." -> ONAY, "Vazgeç, iptal et" -> IPTAL, diğerleri -> null
    private static string? OnayCevabiMi(string metin)
    {
        var sade = new string(metin.ToLower(Tr).Select(c => char.IsLetter(c) ? c : ' ').ToArray());
        var kelimeler = sade.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (kelimeler.Length == 0 || kelimeler.Length > OnayCevabiEnFazlaKelime)
            return null;

        // "Hayır, onaylamıyorum" gibi durumlarda iptal öncelikli
        if (kelimeler.Any(IptalKelimeleri.Contains))
            return Niyetler.Iptal;
        if (kelimeler.Any(OnayKelimeleri.Contains))
            return Niyetler.Onay;
        return null;
    }

    private async Task LogYazAsync(string kullaniciId, string metin, string? niyet, string? islemBilgisi, string sonuc)
    {
        _db.AsistanLoglari.Add(new AsistanLogu
        {
            KullaniciId = kullaniciId,
            SoylenenMetin = Kirp(metin, 500),
            Niyet = niyet,
            IslemBilgisi = islemBilgisi,
            Sonuc = Kirp(sonuc, 500),
            Tarih = DateTime.Now
        });
        await _db.SaveChangesAsync();
    }

    private static string Kirp(string metin, int uzunluk) =>
        metin.Length <= uzunluk ? metin : metin[..uzunluk];
}
