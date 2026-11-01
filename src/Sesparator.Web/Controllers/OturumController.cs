using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sesparator.Web.Models;

namespace Sesparator.Web.Controllers;

public class OturumController : Controller
{
    private readonly SignInManager<Kullanici> _girisYoneticisi;
    private readonly UserManager<Kullanici> _kullaniciYoneticisi;

    public OturumController(SignInManager<Kullanici> girisYoneticisi, UserManager<Kullanici> kullaniciYoneticisi)
    {
        _girisYoneticisi = girisYoneticisi;
        _kullaniciYoneticisi = kullaniciYoneticisi;
    }

    // GET: /Oturum/Giris
    [AllowAnonymous]
    public IActionResult Giris(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToAction("Index", "Home");

        return View(new GirisViewModel { ReturnUrl = returnUrl });
    }

    // POST: /Oturum/Giris
    [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Giris(GirisViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        // UserName = e-posta olduğu için doğrudan e-postayla giriş yapılabiliyor
        var sonuc = await _girisYoneticisi.PasswordSignInAsync(
            model.Eposta, model.Sifre, model.BeniHatirla, lockoutOnFailure: true);

        if (sonuc.Succeeded)
        {
            if (Url.IsLocalUrl(model.ReturnUrl))
                return LocalRedirect(model.ReturnUrl!);

            var kullanici = await _kullaniciYoneticisi.FindByEmailAsync(model.Eposta);
            if (kullanici != null && await _kullaniciYoneticisi.IsInRoleAsync(kullanici, "Yonetici"))
                return RedirectToAction("Index", "Home");   // yönetici paneli 5. haftada gelecek

            return RedirectToAction("Index", "Hesap");
        }

        ModelState.AddModelError(string.Empty, sonuc.IsLockedOut
            ? "Çok fazla hatalı deneme yapıldı. Lütfen 5 dakika sonra tekrar deneyin."
            : "E-posta veya şifre hatalı.");

        return View(model);
    }

    // POST: /Oturum/Cikis
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Cikis()
    {
        await _girisYoneticisi.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // GET: /Oturum/ErisimEngellendi
    [AllowAnonymous]
    public IActionResult ErisimEngellendi() => View();
}
