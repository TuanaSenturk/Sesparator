using Sesparator.Web.Helpers;
using Sesparator.Web.Models.Api;

namespace Sesparator.Web.Services;

public class AsistanServisi
{
    private readonly INiyetServisi _niyetServisi;
    private readonly BankaIslemServisi _banka;

    public AsistanServisi(INiyetServisi niyetServisi, BankaIslemServisi banka)
    {
        _niyetServisi = niyetServisi;
        _banka = banka;
    }

    public async Task<AsistanYaniti> MesajIsleAsync(string kullaniciId, string metin)
    {
        var alicilar = await _banka.AlicilarAsync(kullaniciId);
        var niyet = await _niyetServisi.NiyetCikarAsync(metin, alicilar.Select(a => a.TakmaAd).ToList());

        switch (niyet.Niyet)
        {
            case Niyetler.BakiyeSorgula:
            {
                var hesaplar = await _banka.HesaplarAsync(kullaniciId);
                var mesaj = hesaplar.Count == 0
                    ? "Size ait bir hesap bulunamadı."
                    : string.Join(", ", hesaplar.Select(h =>
                          $"{Bicim.HesapTuruAdi(h.HesapTuru)} hesabınızda {Bicim.Para(h.Bakiye, h.ParaBirimi)}")) + " bulunuyor.";
                return new AsistanYaniti { Niyet = niyet.Niyet, Mesaj = mesaj };
            }

            case Niyetler.ParaTransferi:
            {
                var kontrol = await _banka.TransferKontrolEtAsync(kullaniciId, niyet.Tutar, niyet.AliciTakmaAd, alicilar);
                if (!kontrol.Basarili)
                    return new AsistanYaniti { Niyet = niyet.Niyet, Mesaj = kontrol.Mesaj };

                var t = kontrol.Transfer!;
                return new AsistanYaniti
                {
                    Niyet = niyet.Niyet,
                    OnayGerekli = true,
                    BekleyenTransfer = t,
                    Mesaj = $"{t.AliciAdSoyad} kişisine {Bicim.Para(t.Tutar)} gönderilecek. Onaylıyor musunuz?"
                };
            }

            default:
                return new AsistanYaniti
                {
                    Niyet = Niyetler.Bilinmiyor,
                    Mesaj = "Bunu anlayamadım. Bakiyenizi sorabilir ya da kayıtlı alıcılarınıza para gönderebilirsiniz."
                };
        }
    }
}