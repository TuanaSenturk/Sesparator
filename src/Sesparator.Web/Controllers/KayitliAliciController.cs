using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;
using Sesparator.Web.Models;
using Sesparator.Web.Services;

namespace Sesparator.Web.Controllers;

[Authorize(Roles = "Musteri")]
public class KayitliAliciController : Controller
{
    private readonly UygulamaDbContext _db;
    private readonly UserManager<Kullanici> _kullaniciYoneticisi;
    private readonly KayitliAliciDogrulayici _dogrulayici;

    public KayitliAliciController(UygulamaDbContext db, UserManager<Kullanici> kullaniciYoneticisi,
        KayitliAliciDogrulayici dogrulayici)
    {
        _db = db;
        _kullaniciYoneticisi = kullaniciYoneticisi;
        _dogrulayici = dogrulayici;
    }

    private string KullaniciId => _kullaniciYoneticisi.GetUserId(User)!;

    // GET: /KayitliAlici
    public async Task<IActionResult> Index()
    {
        var kullaniciId = KullaniciId;
        var alicilar = await _db.KayitliAlicilar
            .AsNoTracking()
            .Where(k => k.KullaniciId == kullaniciId)
            .OrderBy(k => k.TakmaAd)
            .ToListAsync();

        return View(alicilar);
    }

    // GET: /KayitliAlici/Ekle
    public IActionResult Ekle() => View(new KayitliAliciGirdisi());

    // POST: /KayitliAlici/Ekle
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Ekle(KayitliAliciGirdisi girdi)
    {
        if (!ModelState.IsValid)
            return View(girdi);

        var kullaniciId = KullaniciId;
        girdi.Temizle();
        await _dogrulayici.DogrulaAsync(ModelState, kullaniciId, girdi);
        if (!ModelState.IsValid)
            return View(girdi);

        _db.KayitliAlicilar.Add(new KayitliAlici
        {
            TakmaAd = girdi.TakmaAd,
            AdSoyad = girdi.AdSoyad,
            Iban = girdi.Iban,
            KullaniciId = kullaniciId
        });
        await _db.SaveChangesAsync();

        TempData["Mesaj"] = $"\"{girdi.TakmaAd}\" kayıtlı alıcılarınıza eklendi.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /KayitliAlici/Duzenle/5
    public async Task<IActionResult> Duzenle(int id)
    {
        var alici = await BulAsync(id, takipEt: false);
        if (alici == null)
            return NotFound();

        return View(new KayitliAliciGirdisi
        {
            TakmaAd = alici.TakmaAd,
            AdSoyad = alici.AdSoyad,
            Iban = alici.Iban
        });
    }

    // POST: /KayitliAlici/Duzenle/5
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Duzenle(int id, KayitliAliciGirdisi girdi)
    {
        var alici = await BulAsync(id, takipEt: true);
        if (alici == null)
            return NotFound();

        if (!ModelState.IsValid)
            return View(girdi);

        girdi.Temizle();
        await _dogrulayici.DogrulaAsync(ModelState, alici.KullaniciId, girdi, haricId: id);
        if (!ModelState.IsValid)
            return View(girdi);

        alici.TakmaAd = girdi.TakmaAd;
        alici.AdSoyad = girdi.AdSoyad;
        alici.Iban = girdi.Iban;
        await _db.SaveChangesAsync();

        TempData["Mesaj"] = $"\"{alici.TakmaAd}\" güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /KayitliAlici/Sil/5  (onay sayfası)
    public async Task<IActionResult> Sil(int id)
    {
        var alici = await BulAsync(id, takipEt: false);
        if (alici == null)
            return NotFound();

        return View(alici);
    }

    // POST: /KayitliAlici/Sil/5
    [HttpPost, ActionName("Sil"), ValidateAntiForgeryToken]
    public async Task<IActionResult> SilOnayla(int id)
    {
        var alici = await BulAsync(id, takipEt: true);
        if (alici == null)
            return NotFound();

        _db.KayitliAlicilar.Remove(alici);
        await _db.SaveChangesAsync();

        TempData["Mesaj"] = $"\"{alici.TakmaAd}\" kayıtlı alıcılarınızdan silindi.";
        return RedirectToAction(nameof(Index));
    }

    private Task<KayitliAlici?> BulAsync(int id, bool takipEt)
    {
        var kullaniciId = KullaniciId;
        var sorgu = takipEt ? _db.KayitliAlicilar : _db.KayitliAlicilar.AsNoTracking();
        return sorgu.FirstOrDefaultAsync(k => k.Id == id && k.KullaniciId == kullaniciId);
    }
}
/*
API controller’ından farkları:

Controller sınıfından türüyor (ControllerBase değil): View döndürebilmek için. [ApiController] yok, yani doğrulama otomatik 
400 döndürmüyor. Bu yüzden if (!ModelState.IsValid) return View(girdi); kontrolünü elle yazıyoruz. Hatalar formun içinde gös-
teriliyor.
[Authorize] içinde JWT şeması yok: Web tarafı, giriş yapınca oluşan oturum çerezini kullanıyor. HesapController da aynı şekilde
çalışıyor.
Her işlem için iki action var: GET ve POST. GET formu gösterir, POST formu kaydeder.
[ValidateAntiForgeryToken]: Başka bir sitenin kullanıcı adına gizlice form göndermesini (CSRF saldırısı) engeller. Form tag 
helper gizli bir token ekler, sunucu da bu token’ı kontrol eder.
Post-Redirect-Get: Kayıttan sonra View yerine RedirectToAction çağrılıyor. Kullanıcı sayfayı yenilediğinde aynı kayıt ikinci 
kez eklenmez.
TempData: Yönlendirmeden sonra açılan sayfaya bir kerelik mesaj taşır (“eklendi”, “silindi” gibi).
Silme işlemi iki adımlı: GET onay sayfasını gösterir, silme sadece POST ile yapılır. GET isteğiyle veri silinmez, çünkü bir 
link tıklaması ya da tarayıcının sayfayı önceden yüklemesi yanlışlıkla kayıt silebilir. C#’ta aynı parametrelerle iki metot 
tanımlanamadığı için POST metodunun adı SilOnayla. [ActionName("Sil")] ile URL yine /Sil olarak kalıyor.
*/