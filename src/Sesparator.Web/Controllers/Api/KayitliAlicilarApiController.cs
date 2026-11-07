using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;
using Sesparator.Web.Models;
using Sesparator.Web.Models.Api;
using Sesparator.Web.Services;

namespace Sesparator.Web.Controllers.Api;

[ApiController]
[Route("api/kayitli-alicilar")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Musteri")]
[Produces("application/json")]
public class KayitliAlicilarApiController : ControllerBase
{
    private readonly UygulamaDbContext _db;
    private readonly UserManager<Kullanici> _kullaniciYoneticisi;
    private readonly KayitliAliciDogrulayici _dogrulayici;

    public KayitliAlicilarApiController(UygulamaDbContext db, UserManager<Kullanici> kullaniciYoneticisi,
        KayitliAliciDogrulayici dogrulayici)
    {
        _db = db;
        _kullaniciYoneticisi = kullaniciYoneticisi;
        _dogrulayici = dogrulayici;
    }

    private string KullaniciId => _kullaniciYoneticisi.GetUserId(User)!;

    // GET: /api/kayitli-alicilar
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<KayitliAliciDto>>> Listele()
    {
        var kullaniciId = KullaniciId;
        var alicilar = await _db.KayitliAlicilar
            .AsNoTracking()
            .Where(k => k.KullaniciId == kullaniciId)
            .OrderBy(k => k.TakmaAd)
            .ToListAsync();

        return alicilar.Select(KayitliAliciDto.Olustur).ToList();
    }

    // GET: /api/kayitli-alicilar/5
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<KayitliAliciDto>> Getir(int id)
    {
        var alici = await BulAsync(id, takipEt: false);
        if (alici == null)
            return BulunamadiYaniti();

        return KayitliAliciDto.Olustur(alici);
    }

    // POST: /api/kayitli-alicilar
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<KayitliAliciDto>> Ekle(KayitliAliciGirdisi girdi)
    {
        var kullaniciId = KullaniciId;
        girdi.Temizle();

        await _dogrulayici.DogrulaAsync(ModelState, kullaniciId, girdi);
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var alici = new KayitliAlici
        {
            TakmaAd = girdi.TakmaAd,
            AdSoyad = girdi.AdSoyad,
            Iban = girdi.Iban,
            KullaniciId = kullaniciId
        };
        _db.KayitliAlicilar.Add(alici);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(Getir), new { id = alici.Id }, KayitliAliciDto.Olustur(alici));
    }

    // PUT: /api/kayitli-alicilar/5
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<KayitliAliciDto>> Guncelle(int id, KayitliAliciGirdisi girdi)
    {
        var alici = await BulAsync(id, takipEt: true);
        if (alici == null)
            return BulunamadiYaniti();

        girdi.Temizle();
        await _dogrulayici.DogrulaAsync(ModelState, alici.KullaniciId, girdi, haricId: id);
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        alici.TakmaAd = girdi.TakmaAd;
        alici.AdSoyad = girdi.AdSoyad;
        alici.Iban = girdi.Iban;
        await _db.SaveChangesAsync();

        return KayitliAliciDto.Olustur(alici);
    }

    // DELETE: /api/kayitli-alicilar/5
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Sil(int id)
    {
        var alici = await BulAsync(id, takipEt: true);
        if (alici == null)
            return BulunamadiYaniti();

        _db.KayitliAlicilar.Remove(alici);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // Yoksa da başkasınınsa da null -> 404
    private Task<KayitliAlici?> BulAsync(int id, bool takipEt)
    {
        var kullaniciId = KullaniciId;
        var sorgu = takipEt ? _db.KayitliAlicilar : _db.KayitliAlicilar.AsNoTracking();
        return sorgu.FirstOrDefaultAsync(k => k.Id == id && k.KullaniciId == kullaniciId);
    }

    private NotFoundObjectResult BulunamadiYaniti() => NotFound(new { mesaj = "Alıcı bulunamadı." });
}