using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;
using Sesparator.Web.Models;

namespace Sesparator.Web.Services;

public class KayitliAliciDogrulayici
{
    private readonly UygulamaDbContext _db;

    public KayitliAliciDogrulayici(UygulamaDbContext db)
    {
        _db = db;
    }

    // haricId: güncellemede alıcının kendisi "zaten var" sayılmasın diye
    public async Task DogrulaAsync(ModelStateDictionary modelState, string kullaniciId,
        KayitliAliciGirdisi girdi, int haricId = 0)
    {
        var digerAlicilar = _db.KayitliAlicilar
            .Where(k => k.KullaniciId == kullaniciId && k.Id != haricId);

        if (await digerAlicilar.AnyAsync(k => k.TakmaAd == girdi.TakmaAd))
            modelState.AddModelError(nameof(girdi.TakmaAd),
                $"\"{girdi.TakmaAd}\" takma adıyla kayıtlı bir alıcınız zaten var.");

        var ayniIbanliAlici = await digerAlicilar
            .Where(k => k.Iban == girdi.Iban)
            .Select(k => k.TakmaAd)
            .FirstOrDefaultAsync();
        if (ayniIbanliAlici != null)
            modelState.AddModelError(nameof(girdi.Iban),
                $"Bu IBAN zaten \"{ayniIbanliAlici}\" adıyla kayıtlı.");

        if (await _db.Hesaplar.AnyAsync(h => h.KullaniciId == kullaniciId && h.Iban == girdi.Iban))
            modelState.AddModelError(nameof(girdi.Iban),
                "Kendi hesabınızı alıcı olarak ekleyemezsiniz.");
    }
}

/*
 Ne işe yarar: [Required] gibi attribute’lar sadece gelen değere bakabilir. “Bu takma ad zaten var mı?”
sorusunun cevabı ise veritabanında. Bu kontroller ayrı bir serviste duruyor ki API ve web sayfası aynı kodu kullansın.

Aynı takma ad: DbContext içinde (KullaniciId, TakmaAd) için benzersiz indeks zaten var. Bu kontrol olmasa kayıt sırasında 
veritabanı hata fırlatır ve kullanıcı 500 hatası görür. Kontrolle birlikte anlaşılır bir mesaj alır. Sesli komutta “Annem” 
dendiğinde tek bir alıcı bulunması da bu kurala bağlı.
 Kendi hesabı: Kullanıcının kendi IBAN’ını alıcı olarak eklemesini engeller.
modelState.AddModelError: Hatayı ilgili alana bağlar. Formda hata, ilgili kutunun altında görünür.
*/
