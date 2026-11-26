using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Data;
using Sesparator.Web.Helpers;
using Sesparator.Web.Models;
using Sesparator.Web.Models.Yonetici;

namespace Sesparator.Web.Controllers;

// Yönetici paneli: kullanıcı yönetimi ve işlem izleme.
// Sınıfın tamamı rol ile korunur; müşteri adresi elle yazsa bile ErisimEngellendi sayfasına düşer.
[Authorize(Roles = "Yonetici")]
public class YoneticiController : Controller
{
    private const string MusteriRolu = "Musteri";
    private const int SayfaBoyutu = 50;
    private const int DetaydakiIslemSayisi = 20;

    private readonly UygulamaDbContext _db;
    private readonly UserManager<Kullanici> _kullaniciYoneticisi;

    public YoneticiController(UygulamaDbContext db, UserManager<Kullanici> kullaniciYoneticisi)
    {
        _db = db;
        _kullaniciYoneticisi = kullaniciYoneticisi;
    }

    // Sadece Musteri rolündeki kullanıcılar (yönetici listeye hiç girmez). Tek SQL sorgusuna çevrilir.
    private IQueryable<Kullanici> Musteriler() =>
        _db.Users.Where(k => _db.UserRoles.Any(ur => ur.UserId == k.Id &&
            _db.Roles.Any(r => r.Id == ur.RoleId && r.Name == MusteriRolu)));

    // Kullanıcı + hesap sayısı + TRY bakiye toplamı, tek sorguda
    private static IQueryable<KullaniciSatiri> SatiraCevir(IQueryable<Kullanici> kullanicilar) =>
        kullanicilar.Select(k => new KullaniciSatiri
        {
            Id = k.Id,
            AdSoyad = k.Ad + " " + k.Soyad,
            Eposta = k.Email ?? "",
            HesapSayisi = k.Hesaplar.Count,
            ToplamBakiye = k.Hesaplar.Where(h => h.ParaBirimi == "TRY").Sum(h => h.Bakiye),
            KilitBitisi = k.LockoutEnd
        });

    // Entity yerine sadece tabloda gereken alanlar çekilir
    private static IQueryable<IslemSatiri> SatiraCevir(IQueryable<Islem> islemler) =>
        islemler.Select(i => new IslemSatiri
        {
            Id = i.Id,
            Tarih = i.Tarih,
            MusteriId = i.Hesap!.KullaniciId,
            MusteriAdSoyad = i.Hesap.Kullanici!.Ad + " " + i.Hesap.Kullanici.Soyad,
            HesapIban = i.Hesap.Iban,
            ParaBirimi = i.Hesap.ParaBirimi,
            IslemTuru = i.IslemTuru,
            Kanal = i.Kanal,
            Durum = i.Durum,
            Tutar = i.Tutar,
            Aciklama = i.Aciklama
        });

    // Aynı saniyedeki işlemler de sabit sırada kalsın (sayfalama kaymasın)
    private static IQueryable<Islem> YenidenEskiye(IQueryable<Islem> islemler) =>
        islemler.OrderByDescending(i => i.Tarih).ThenByDescending(i => i.Id);

    // GET: /Yonetici
    public async Task<IActionResult> Index()
    {
        // Aralık karşılaştırması: Tarih sütunu fonksiyona sokulmadığı için indeks kullanılabilir
        var bugun = DateTime.Today;
        var yarin = bugun.AddDays(1);
        var bugunku = _db.Islemler.Where(i => i.Tarih >= bugun && i.Tarih < yarin);

        return View(new YoneticiOzetModeli
        {
            MusteriSayisi = await Musteriler().CountAsync(),
            BugunkuIslemSayisi = await bugunku.CountAsync(),
            BugunkuSesliIslemSayisi = await bugunku.CountAsync(i => i.Kanal == IslemKanali.Ses),
            BekleyenIslemSayisi = await _db.Islemler.CountAsync(i => i.Durum == IslemDurumu.Beklemede)
        });
    }

    // GET: /Yonetici/Kullanicilar?arama=koç
    public async Task<IActionResult> Kullanicilar(string? arama)
    {
        var sorgu = Musteriler();
        if (!string.IsNullOrWhiteSpace(arama))
        {
            var a = arama.Trim();
            sorgu = sorgu.Where(k => k.Ad.Contains(a) || k.Soyad.Contains(a) ||
                                     (k.Ad + " " + k.Soyad).Contains(a) || k.Email!.Contains(a));
        }

        var kullanicilar = await SatiraCevir(sorgu.OrderBy(k => k.Ad).ThenBy(k => k.Soyad))
            .AsNoTracking().ToListAsync();

        return View(new KullaniciListesiModeli { Arama = arama, Kullanicilar = kullanicilar });
    }

    // GET: /Yonetici/KullaniciDetay/{id}
    public async Task<IActionResult> KullaniciDetay(string id)
    {
        // Müşteri değilse (ör. yönetici Id'si) 404
        var kullanici = await SatiraCevir(Musteriler().Where(k => k.Id == id))
            .AsNoTracking().FirstOrDefaultAsync();
        if (kullanici is null)
            return NotFound();

        var hesaplar = await _db.Hesaplar.AsNoTracking()
            .Where(h => h.KullaniciId == id)
            .OrderBy(h => h.HesapTuru)
            .ToListAsync();

        var sonIslemler = await SatiraCevir(YenidenEskiye(_db.Islemler.Where(i => i.Hesap!.KullaniciId == id))
                .Take(DetaydakiIslemSayisi))
            .AsNoTracking().ToListAsync();

        return View(new KullaniciDetayModeli
        {
            Kullanici = kullanici,
            Hesaplar = hesaplar,
            SonIslemler = sonIslemler
        });
    }

    // POST: /Yonetici/Kilitle/{id}
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Kilitle(string id, string? donusAdresi)
    {
        var hedef = await DegistirilebilirMusteriAsync(id);
        if (hedef is null)
        {
            TempData["Hata"] = "Bu kullanıcı kilitlenemez.";
            return Geri(donusAdresi);
        }

        await _kullaniciYoneticisi.SetLockoutEnabledAsync(hedef, true);
        await _kullaniciYoneticisi.SetLockoutEndDateAsync(hedef, KilitYardimcisi.YoneticiKilidiBitisi());
        // Güvenlik damgası değişince açık web oturumu en geç 1 dakikada düşer (Program.cs: ValidationInterval)
        await _kullaniciYoneticisi.UpdateSecurityStampAsync(hedef);

        TempData["Mesaj"] = $"{hedef.Ad} {hedef.Soyad} kilitlendi.";
        return Geri(donusAdresi);
    }

    // POST: /Yonetici/KilidiAc/{id}
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> KilidiAc(string id, string? donusAdresi)
    {
        var hedef = await DegistirilebilirMusteriAsync(id);
        if (hedef is null)
        {
            TempData["Hata"] = "Bu kullanıcının kilidi açılamaz.";
            return Geri(donusAdresi);
        }

        await _kullaniciYoneticisi.SetLockoutEndDateAsync(hedef, null);
        await _kullaniciYoneticisi.ResetAccessFailedCountAsync(hedef);

        TempData["Mesaj"] = $"{hedef.Ad} {hedef.Soyad} kullanıcısının kilidi açıldı.";
        return Geri(donusAdresi);
    }

    // GET: /Yonetici/Islemler?Kanal=Ses&Durum=IptalEdildi&Sayfa=2
    public async Task<IActionResult> Islemler([FromQuery] IslemFiltresi filtre)
    {
        // Sadece doldurulan filtreler eklenir
        var sorgu = _db.Islemler.AsQueryable();
        if (filtre.BaslangicTarihi is { } bas)
            sorgu = sorgu.Where(i => i.Tarih >= bas.Date);
        if (filtre.BitisTarihi is { } bit)
        {
            var sonraki = bit.Date.AddDays(1);   // bitiş günü de dahil
            sorgu = sorgu.Where(i => i.Tarih < sonraki);
        }
        if (filtre.Kanal is { } kanal)
            sorgu = sorgu.Where(i => i.Kanal == kanal);
        if (filtre.Durum is { } durum)
            sorgu = sorgu.Where(i => i.Durum == durum);
        if (filtre.Tur is { } tur)
            sorgu = sorgu.Where(i => i.IslemTuru == tur);

        var toplam = await sorgu.CountAsync();
        var toplamSayfa = Math.Max(1, (int)Math.Ceiling(toplam / (double)SayfaBoyutu));
        filtre.Sayfa = Math.Clamp(filtre.Sayfa, 1, toplamSayfa);

        var islemler = await SatiraCevir(YenidenEskiye(sorgu)
                .Skip((filtre.Sayfa - 1) * SayfaBoyutu)
                .Take(SayfaBoyutu))
            .AsNoTracking().ToListAsync();

        return View(new IslemIzlemeModeli
        {
            Filtre = filtre,
            Islemler = islemler,
            ToplamKayit = toplam,
            ToplamSayfa = toplamSayfa
        });
    }

    // Kilit işlemleri sadece müşterilere uygulanır; yönetici kendini ya da başka yöneticiyi kilitleyemez.
    // Kontrol sunucuda: biri elle POST atsa bile geçemez.
    private async Task<Kullanici?> DegistirilebilirMusteriAsync(string id)
    {
        if (id == _kullaniciYoneticisi.GetUserId(User))
            return null;

        var kullanici = await _kullaniciYoneticisi.FindByIdAsync(id);
        if (kullanici is null || !await _kullaniciYoneticisi.IsInRoleAsync(kullanici, MusteriRolu))
            return null;

        return kullanici;
    }

    // Sadece uygulama içi adrese geri dön (açık yönlendirme olmasın)
    private IActionResult Geri(string? donusAdresi) =>
        Url.IsLocalUrl(donusAdresi) ? LocalRedirect(donusAdresi!) : RedirectToAction(nameof(Kullanicilar));
}
