using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sesparator.Web.Models;
using Sesparator.Web.Models.Api;
using Sesparator.Web.Services;

namespace Sesparator.Web.Controllers.Api;

// Web (çerez) ve mobil (JWT) aynı uç noktayı kullanır
[ApiController]
[Route("api/asistan")]
[Authorize(Roles = "Musteri",
    AuthenticationSchemes = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme)]
[Produces("application/json")]
public class AsistanApiController : ControllerBase
{
    private const string AsistanHatasi = "Asistan şu an yanıt veremiyor, lütfen tekrar deneyin.";

    private readonly AsistanServisi _asistan;
    private readonly UserManager<Kullanici> _kullaniciYoneticisi;

    public AsistanApiController(AsistanServisi asistan, UserManager<Kullanici> kullaniciYoneticisi)
    {
        _asistan = asistan;
        _kullaniciYoneticisi = kullaniciYoneticisi;
    }

    // POST: /api/asistan/mesaj   { "metin": "Bakiyem ne kadar?" }
    [HttpPost("mesaj")]
    public async Task<ActionResult<AsistanYaniti>> Mesaj(AsistanIstegi istek)
    {
        var kullaniciId = _kullaniciYoneticisi.GetUserId(User)!;
        var metin = istek.Metin.Trim();

        try
        {
            return await _asistan.MesajIsleAsync(kullaniciId, metin);
        }
        catch (KotaTukendiException ex)
        {
            await _asistan.HataLogYazAsync(kullaniciId, metin, ex.Message);
            return StatusCode(StatusCodes.Status429TooManyRequests, new { mesaj = ex.Message });
        }
        catch (HttpRequestException)
        {
            await _asistan.HataLogYazAsync(kullaniciId, metin, AsistanHatasi);
            return StatusCode(StatusCodes.Status502BadGateway, new { mesaj = AsistanHatasi });
        }
    }
}