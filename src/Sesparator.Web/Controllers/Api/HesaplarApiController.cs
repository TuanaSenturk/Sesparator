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

    // GET: /api/hesaplar/5/islemler
    [HttpGet("{id:int}/islemler")]
    public async Task<ActionResult<List<IslemDto>>> Islemler(int id)
    {
        var kullaniciId = _kullaniciYoneticisi.GetUserId(User)!;

        // Hesap yoksa da başkasınınsa da 404: başka kullanıcının hesap Id'lerinin varlığı belli olmasın
        var hesapBenimMi = await _db.Hesaplar
            .AnyAsync(h => h.Id == id && h.KullaniciId == kullaniciId);
        if (!hesapBenimMi)
            return NotFound(new { mesaj = "Hesap bulunamadı." });

        var islemler = await _db.Islemler
            .AsNoTracking()
            .Where(i => i.HesapId == id)
            .OrderByDescending(i => i.Tarih)   // en yeni işlem en üstte
            .ThenByDescending(i => i.Id)       // aynı andaki işlemlerin sırası sabit kalsın
            .ToListAsync();

        // Enum'lar metin olarak gider: "GidenTransfer", "Ses", "Tamamlandi"
        return islemler
            .Select(i => new IslemDto(i.Id, i.IslemTuru.ToString(), i.Tutar, i.AliciIban,
                i.Aciklama, i.Tarih, i.Kanal.ToString(), i.Durum.ToString()))
            .ToList();
    }
}