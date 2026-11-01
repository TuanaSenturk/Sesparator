using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sesparator.Web.Models;
using Sesparator.Web.Services;

namespace Sesparator.Web.Controllers.Api;

[ApiController]
[Route("api/oturum")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class OturumApiController : ControllerBase
{
    private readonly UserManager<Kullanici> _kullaniciYoneticisi;
    private readonly SignInManager<Kullanici> _girisYoneticisi;
    private readonly JwtServisi _jwtServisi;

    public OturumApiController(UserManager<Kullanici> kullaniciYoneticisi,
        SignInManager<Kullanici> girisYoneticisi, JwtServisi jwtServisi)
    {
        _kullaniciYoneticisi = kullaniciYoneticisi;
        _girisYoneticisi = girisYoneticisi;
        _jwtServisi = jwtServisi;
    }

    // POST: /api/oturum/giris
    [AllowAnonymous]
    [HttpPost("giris")]
    public async Task<ActionResult<TokenYaniti>> Giris(GirisIstegi istek)
    {
        var kullanici = await _kullaniciYoneticisi.FindByEmailAsync(istek.Eposta);
        if (kullanici == null)
            return Unauthorized(new { mesaj = "E-posta veya şifre hatalı." });

        // Çerez oluşturmaz, sadece şifreyi ve kilit durumunu kontrol eder
        var sonuc = await _girisYoneticisi.CheckPasswordSignInAsync(kullanici, istek.Sifre, lockoutOnFailure: true);
        if (sonuc.IsLockedOut)
            return Unauthorized(new { mesaj = "Çok fazla hatalı deneme. 5 dakika sonra tekrar deneyin." });
        if (!sonuc.Succeeded)
            return Unauthorized(new { mesaj = "E-posta veya şifre hatalı." });

        var roller = await _kullaniciYoneticisi.GetRolesAsync(kullanici);
        var (token, bitis) = _jwtServisi.Olustur(kullanici, roller);

        return Ok(new TokenYaniti(token, bitis, kullanici.Ad, kullanici.Soyad, roller));
    }

    // GET: /api/oturum/ben  (token'ın çalıştığını test etmek için)
    [HttpGet("ben")]
    public IActionResult Ben() => Ok(new
    {
        id = _kullaniciYoneticisi.GetUserId(User),
        eposta = User.FindFirstValue(ClaimTypes.Email),
        roller = User.FindAll(ClaimTypes.Role).Select(c => c.Value)
    });
}