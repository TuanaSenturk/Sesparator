using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;

namespace Sesparator.Web.Controllers
{
    public class HesapController : Controller
    {
        // Giriş sistemi (2. hafta) gelene kadar sabit örnek müşteri: Ayşe Yılmaz
        private const string DemoKullaniciId = "00000000-0000-0000-0001-000000000003";

        private readonly UygulamaDbContext _db;

        public HesapController(UygulamaDbContext db)
        {
            _db = db;
        }

        // GET: /Hesap
        public async Task<IActionResult> Index()
        {
            var hesaplar = await _db.Hesaplar
                .AsNoTracking()
                .Where(h => h.KullaniciId == DemoKullaniciId)
                .OrderBy(h => h.HesapTuru)
                .ToListAsync();

            return View(hesaplar);
        }
        // GET: /Hesap/Detay/5
        public async Task<IActionResult> Detay(int id)
        {
            var hesap = await _db.Hesaplar
                .AsNoTracking()
                .Include(h => h.Islemler.OrderByDescending(i => i.Tarih))
                .FirstOrDefaultAsync(h => h.Id == id && h.KullaniciId == DemoKullaniciId);

            if (hesap == null)
                return NotFound();

            return View(hesap);
        }
    }
}