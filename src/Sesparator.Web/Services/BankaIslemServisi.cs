using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;
using Sesparator.Web.Helpers;
using Sesparator.Web.Models;
using Sesparator.Web.Models.Api;

namespace Sesparator.Web.Services;

public class BankaIslemServisi
{
    private static readonly CultureInfo Tr = new("tr-TR");

    private readonly UygulamaDbContext _db;
    private readonly decimal _gunlukSesliLimit;

    public BankaIslemServisi(UygulamaDbContext db, IConfiguration ayarlar)
    {
        _db = db;
        _gunlukSesliLimit = ayarlar.GetValue("Asistan:GunlukSesliLimit", 10000m);
    }

    public Task<List<Hesap>> HesaplarAsync(string kullaniciId) =>
        _db.Hesaplar.AsNoTracking()
            .Where(h => h.KullaniciId == kullaniciId)
            .OrderBy(h => h.HesapTuru)
            .ToListAsync();

    public Task<List<KayitliAlici>> AlicilarAsync(string kullaniciId) =>
        _db.KayitliAlicilar.AsNoTracking()
            .Where(k => k.KullaniciId == kullaniciId)
            .ToListAsync();

    // Sesli transfer her zaman TL vadesiz hesaptan yapılır
    public Task<Hesap?> VadesizHesapAsync(string kullaniciId) =>
        _db.Hesaplar.AsNoTracking()
            .Where(h => h.KullaniciId == kullaniciId && h.HesapTuru == HesapTuru.Vadesiz && h.ParaBirimi == "TRY")
            .OrderBy(h => h.Id)
            .FirstOrDefaultAsync();

    // Bugün sesle yapılmış, tamamlanmış giden transferlerin toplamı
    public async Task<decimal> BugunkuSesliTransferAsync(int hesapId)
    {
        var bugun = DateTime.Today;
        return await _db.Islemler
            .Where(i => i.HesapId == hesapId
                     && i.IslemTuru == IslemTuru.GidenTransfer
                     && i.Kanal == IslemKanali.Ses
                     && i.Durum == IslemDurumu.Tamamlandi
                     && i.Tarih >= bugun)
            .SumAsync(i => (decimal?)i.Tutar) ?? 0m;
    }

    public async Task<TransferKontrolSonucu> TransferKontrolEtAsync(
        string kullaniciId, decimal? tutar, string? aliciTakmaAd, IReadOnlyList<KayitliAlici> alicilar)
    {
        if (tutar is null || tutar <= 0)
            return TransferKontrolSonucu.Hata("Ne kadar göndermek istediğinizi anlayamadım.");

        var alici = alicilar.FirstOrDefault(a =>
            string.Compare(a.TakmaAd, aliciTakmaAd?.Trim(), Tr, CompareOptions.IgnoreCase) == 0);
        if (alici is null)
            return TransferKontrolSonucu.Hata("Bu kişi kayıtlı alıcılarınız arasında yok.");

        var hesap = await VadesizHesapAsync(kullaniciId);
        if (hesap is null)
            return TransferKontrolSonucu.Hata("Transfer yapılabilecek bir vadesiz hesabınız bulunamadı.");

        if (hesap.Bakiye < tutar)
            return TransferKontrolSonucu.Hata($"Bakiyeniz yetersiz. Vadesiz hesabınızda {Bicim.Para(hesap.Bakiye)} var.");

        var bugunku = await BugunkuSesliTransferAsync(hesap.Id);
        if (bugunku + tutar > _gunlukSesliLimit)
            return TransferKontrolSonucu.Hata(
                $"Günlük sesli işlem limitiniz {Bicim.Para(_gunlukSesliLimit)}. " +
                $"Bugün en fazla {Bicim.Para(_gunlukSesliLimit - bugunku)} daha gönderebilirsiniz.");

        return TransferKontrolSonucu.Tamam(new BekleyenTransfer
        {
            HesapId = hesap.Id,
            KayitliAliciId = alici.Id,
            AliciAdSoyad = alici.AdSoyad,
            AliciIban = alici.Iban,
            Tutar = tutar.Value
        });
    }

    // ---------------- Onay / iptal akışı ----------------

    // Onay bekleyen sesli transfer bu süreden eskiyse "evet" ile onaylanamaz
    private static readonly TimeSpan OnayBeklemeSuresi = TimeSpan.FromMinutes(5);

    private IQueryable<Islem> BekleyenSesliIslemler(string kullaniciId) =>
        _db.Islemler.Where(i => i.Hesap!.KullaniciId == kullaniciId
                             && i.IslemTuru == IslemTuru.GidenTransfer
                             && i.Kanal == IslemKanali.Ses
                             && i.Durum == IslemDurumu.Beklemede);

    // Kullanıcının son 5 dakika içindeki, onay bekleyen sesli transferi
    public Task<Islem?> BekleyenSesliIslemAsync(string kullaniciId)
    {
        var sinir = DateTime.Now - OnayBeklemeSuresi;
        return BekleyenSesliIslemler(kullaniciId).AsNoTracking()
            .Where(i => i.Tarih >= sinir)
            .OrderByDescending(i => i.Tarih)
            .FirstOrDefaultAsync();
    }

    // Kontrolden geçen transferi "Beklemede" olarak kaydeder. Aynı anda en fazla bir bekleyen
    // sesli işlem olsun diye kullanıcının eski bekleyen işlemleri iptal edilir.
    public async Task<int> BekleyenTransferKaydetAsync(string kullaniciId, BekleyenTransfer t)
    {
        var eskiler = await BekleyenSesliIslemler(kullaniciId).ToListAsync();
        foreach (var eski in eskiler)
            eski.Durum = IslemDurumu.IptalEdildi;

        var islem = new Islem
        {
            HesapId = t.HesapId,
            IslemTuru = IslemTuru.GidenTransfer,
            Tutar = t.Tutar,
            AliciIban = t.AliciIban,
            Aciklama = $"{t.AliciAdSoyad} (sesli)",
            Tarih = DateTime.Now,
            Kanal = IslemKanali.Ses,
            Durum = IslemDurumu.Beklemede
        };
        _db.Islemler.Add(islem);
        await _db.SaveChangesAsync();
        return islem.Id;
    }

    public async Task<bool> BekleyenIslemIptalEtAsync(string kullaniciId, int islemId)
    {
        var islem = await _db.Islemler.FirstOrDefaultAsync(i =>
            i.Id == islemId && i.Hesap!.KullaniciId == kullaniciId && i.Durum == IslemDurumu.Beklemede);
        if (islem is null)
            return false;

        islem.Durum = IslemDurumu.IptalEdildi;
        await _db.SaveChangesAsync();
        return true;
    }

    // Onaylanan transferi gerçekleştirir. Sesli onay akışı ve mobil para gönderme formu ortak kullanır.
    public async Task<TransferSonucu> TransferGerceklestirAsync(string kullaniciId, int islemId)
    {
        // Takipli sorgu: hesap ve işlemde yapılan değişiklikler SaveChanges ile kaydedilecek
        var islem = await _db.Islemler.Include(i => i.Hesap)
            .FirstOrDefaultAsync(i => i.Id == islemId && i.Hesap!.KullaniciId == kullaniciId);
        if (islem is null)
            return new TransferSonucu { Mesaj = "Onaylanacak işlem bulunamadı." };

        // Aynı işlem iki kez onaylanamaz
        if (islem.Durum != IslemDurumu.Beklemede)
            return new TransferSonucu { Mesaj = "Bu işlem artık onay beklemiyor." };

        var hesap = islem.Hesap!;

        // Onay gelene kadar bakiye ya da günlük toplam değişmiş olabilir: tekrar kontrol et
        string? hata = null;
        if (hesap.Bakiye < islem.Tutar)
        {
            hata = $"Bakiyeniz yetersiz. Vadesiz hesabınızda {Bicim.Para(hesap.Bakiye, hesap.ParaBirimi)} var.";
        }
        else if (islem.Kanal == IslemKanali.Ses)
        {
            var bugunku = await BugunkuSesliTransferAsync(hesap.Id);
            if (bugunku + islem.Tutar > _gunlukSesliLimit)
                hata = $"Günlük sesli işlem limitiniz {Bicim.Para(_gunlukSesliLimit)}. " +
                       $"Bugün en fazla {Bicim.Para(_gunlukSesliLimit - bugunku)} daha gönderebilirsiniz.";
        }

        if (hata is not null)
        {
            islem.Durum = IslemDurumu.Basarisiz;
            await _db.SaveChangesAsync();
            return new TransferSonucu { Mesaj = hata };
        }

        hesap.Bakiye -= islem.Tutar;
        islem.Durum = IslemDurumu.Tamamlandi;
        islem.Tarih = DateTime.Now;

        // Alıcının IBAN'ı sistemdeki bir TL hesabına aitse para o hesaba da eklenir
        var aliciIban = IbanYardimcisi.Normallestir(islem.AliciIban);
        var aliciHesap = aliciIban.Length == 0
            ? null
            : await _db.Hesaplar.FirstOrDefaultAsync(h => h.Iban == aliciIban && h.ParaBirimi == "TRY" && h.Id != hesap.Id);
        if (aliciHesap is not null)
        {
            var gonderen = await _db.Users.AsNoTracking()
                .Where(u => u.Id == kullaniciId)
                .Select(u => u.Ad + " " + u.Soyad)
                .FirstOrDefaultAsync();

            aliciHesap.Bakiye += islem.Tutar;
            _db.Islemler.Add(new Islem
            {
                HesapId = aliciHesap.Id,
                IslemTuru = IslemTuru.GelenTransfer,
                Tutar = islem.Tutar,
                AliciIban = null,
                Aciklama = $"{gonderen} (gelen transfer)",
                Tarih = islem.Tarih,
                Kanal = islem.Kanal,
                Durum = IslemDurumu.Tamamlandi
            });
        }

        // Tek SaveChanges: gönderen, alıcı ve işlem kayıtları ya birlikte kaydedilir ya hiçbiri
        await _db.SaveChangesAsync();

        return new TransferSonucu
        {
            Basarili = true,
            Mesaj = $"Transfer tamamlandı. {Bicim.Para(islem.Tutar)} gönderildi. " +
                    $"Vadesiz hesabınızın yeni bakiyesi {Bicim.Para(hesap.Bakiye, hesap.ParaBirimi)}."
        };
    }
}