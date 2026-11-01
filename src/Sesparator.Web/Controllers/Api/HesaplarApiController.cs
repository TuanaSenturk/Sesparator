using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;
using Sesparator.Web.Models.Api;

namespace Sesparator.Web.Controllers.Api;

// [ApiController]: View değil JSON döndürür.  [Route]: adres /api/hesaplar
[ApiController]
[Route("api/hesaplar")]
public class HesaplarApiController : ControllerBase
{
    // Şimdilik sabit demo müşteri (Ayşe Yılmaz). 2. haftada JWT'deki kullanıcıdan alınacak.
    private const string DemoKullaniciId = "00000000-0000-0000-0001-000000000003";

    private readonly UygulamaDbContext _db;

    // Dependency Injection: DbContext'i Program.cs'teki AddDbContext verir
    public HesaplarApiController(UygulamaDbContext db)
    {
        _db = db;
    }

    // GET: /api/hesaplar
    [HttpGet]
    public async Task<ActionResult<List<HesapDto>>> Listele()
    {
        var hesaplar = await _db.Hesaplar
            .AsNoTracking()   // sadece okuma, değişiklik takibi gereksiz
            .Where(h => h.KullaniciId == DemoKullaniciId)
            .OrderBy(h => h.HesapTuru)
            .ToListAsync();

        // Entity -> DTO. Enum'u "Vadesiz"/"Vadeli" metnine çeviriyoruz.
        return hesaplar
            .Select(h => new HesapDto(h.Id, h.Iban, h.HesapTuru.ToString(), h.ParaBirimi, h.Bakiye))
            .ToList();
    }
}