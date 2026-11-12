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
}