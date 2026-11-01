using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Sesparator.Web.Models;

namespace Sesparator.Web.Controllers
{
    [Authorize(Roles = "Musteri")]

    public class HesapController : Controller
    {
        private readonly UygulamaDbContext _db;
        private readonly UserManager<Kullanici> _kullaniciYoneticisi;

        public HesapController(UygulamaDbContext db, UserManager<Kullanici> kullaniciYoneticisi)
        {
            _db = db;
            _kullaniciYoneticisi = kullaniciYoneticisi;
        }

        // [Authorize] sayesinde buraya sadece giriş yapmış kullanıcı gelir, Id boş olamaz
        private string KullaniciId => _kullaniciYoneticisi.GetUserId(User)!;

        // GET: /Hesap
        public async Task<IActionResult> Index()
        {
            var kullaniciId = KullaniciId;
            var hesaplar = await _db.Hesaplar
                .AsNoTracking()
                .Where(h => h.KullaniciId == kullaniciId)
                .OrderBy(h => h.HesapTuru)
                .ToListAsync();

            return View(hesaplar);
        }
        // GET: /Hesap/Detay/5
        public async Task<IActionResult> Detay(int id)
        {
            var kullaniciId = KullaniciId;
            var hesap = await _db.Hesaplar
                .AsNoTracking()
                .Include(h => h.Islemler.OrderByDescending(i => i.Tarih))
                .FirstOrDefaultAsync(h => h.Id == id && h.KullaniciId == kullaniciId);

            // Hesap yoksa da başkasınınsa da 404: başka kullanıcının hesap Id'lerinin varlığı belli olmasın
            if (hesap == null)
                return NotFound();

            return View(hesap);
        }
    }
}