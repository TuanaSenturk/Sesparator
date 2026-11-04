using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sesparator.Web.Models.Api;
using Sesparator.Web.Services;

namespace Sesparator.Web.Controllers.Api;

// Web (çerez) ve mobil (JWT) aynı uç noktaları kullanır
[ApiController]
[Route("api/ses")]
[Authorize(Roles = "Musteri",
    AuthenticationSchemes = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme)]
public class SesApiController : ControllerBase
{
    // Komutlar kısa; 20 saniyelik webm/opus kaydı ~100 KB tutar
    private const long EnBuyukSesBoyutu = 2 * 1024 * 1024;

    // Gemini beklenmedik hata döndürürse (bozuk ses, geçersiz anahtar vb.) kullanıcıya gösterilen mesaj
    private const string SesServisiHatasi = "Ses servisi şu an yanıt veremiyor, lütfen tekrar deneyin.";

    private readonly ISesServisi _sesServisi;

    public SesApiController(ISesServisi sesServisi)
    {
        _sesServisi = sesServisi;
    }

    // POST: /api/ses/metne-cevir  (multipart/form-data, alan adı: ses)
    [HttpPost("metne-cevir")]
    [RequestSizeLimit(EnBuyukSesBoyutu)]
    public async Task<ActionResult<MetinYaniti>> MetneCevir(IFormFile ses)
    {
        if (ses.Length == 0)
            return BadRequest(new { mesaj = "Ses kaydı boş." });

        using var ms = new MemoryStream();
        await ses.CopyToAsync(ms);

        try
        {
            // "audio/webm;codecs=opus" -> "audio/webm"
            var icerikTuru = ses.ContentType.Split(';')[0];
            var metin = await _sesServisi.MetneCevirAsync(ms.ToArray(), icerikTuru);
            if (metin == null)
                return UnprocessableEntity(new { mesaj = "Konuşma anlaşılamadı, lütfen tekrar deneyin." });

            return new MetinYaniti(metin);
        }
        catch (KotaTukendiException ex)
        {
            return StatusCode(StatusCodes.Status429TooManyRequests, new { mesaj = ex.Message });
        }
        catch (HttpRequestException)
        {
            return StatusCode(StatusCodes.Status502BadGateway, new { mesaj = SesServisiHatasi });
        }
    }

    // POST: /api/ses/sese-cevir  { "metin": "..." }  ->  ses dosyası
    [HttpPost("sese-cevir")]
    public async Task<IActionResult> SeseCevir(SeseCevirIstegi istek)
    {
        try
        {
            var (ses, icerikTuru) = await _sesServisi.SeseCevirAsync(istek.Metin);
            return File(ses, icerikTuru);
        }
        catch (KotaTukendiException ex)
        {
            return StatusCode(StatusCodes.Status429TooManyRequests, new { mesaj = ex.Message });
        }
        catch (HttpRequestException)
        {
            return StatusCode(StatusCodes.Status502BadGateway, new { mesaj = SesServisiHatasi });
        }
    }
}
