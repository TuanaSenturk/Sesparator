using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;

namespace Sesparator.Web.Controllers.Api;

[ApiController]
[Route("api/hesaplar")]
public class HesaplarApiController : ControllerBase
{
    private readonly UygulamaDbContext _db;
    public HesaplarApiController(UygulamaDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var kullaniciId = "00000000-0000-0000-0001-000000000003"; // JWT gelince değişecek
        var hesaplar = await _db.Hesaplar.AsNoTracking()
            .Where(h => h.KullaniciId == kullaniciId)
            .Select(h => new { h.Id, h.Iban, h.HesapTuru, h.Bakiye, h.ParaBirimi })
            .ToListAsync();
        return Ok(hesaplar);
    }
}