using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;
using Sesparator.Web.Models.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Sesparator.Web.Models;

namespace Sesparator.Web.Controllers.Api;

// [ApiController]: View değil JSON döndürür.  [Route]: adres /api/hesaplar
[ApiController]
[Route("api/hesaplar")]
// Sadece geçerli JWT gönderen ve rolü Musteri olan kullanıcılar erişebilir.
// Token yoksa ya da süresi dolmuşsa 401, rol yanlışsa (ör. yönetici) 403 döner.
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Musteri")]
public class HesaplarApiController : ControllerBase
{

    private readonly UygulamaDbContext _db;
    private readonly UserManager<Kullanici> _kullaniciYoneticisi;

    public HesaplarApiController(UygulamaDbContext db, UserManager<Kullanici> kullaniciYoneticisi)
    {
        _db = db;
        _kullaniciYoneticisi = kullaniciYoneticisi;
    }

    // GET: /api/hesaplar
    [HttpGet]
    public async Task<ActionResult<List<HesapDto>>> Listele()
    {
        // Kullanıcı Id'si token'ın içinden okunur ([Authorize] sayesinde boş olamaz)
        var kullaniciId = _kullaniciYoneticisi.GetUserId(User)!;

        var hesaplar = await _db.Hesaplar
            .AsNoTracking()   // sadece okuma, değişiklik takibi gereksiz
            .Where(h => h.KullaniciId == kullaniciId)
            .OrderBy(h => h.HesapTuru)
            .ToListAsync();

        // Entity -> DTO. Enum'u "Vadesiz"/"Vadeli" metnine çeviriyoruz.
        return hesaplar
            .Select(h => new HesapDto(h.Id, h.Iban, h.HesapTuru.ToString(), h.ParaBirimi, h.Bakiye))
            .ToList();
    }
}