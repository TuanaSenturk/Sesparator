using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sesparator.Web.Models;
using Sesparator.Web.Models.Api;
using Sesparator.Web.Services;

namespace Sesparator.Web.Controllers.Api;

[ApiController]
[Route("api/transferler")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Musteri")]
[Produces("application/json")]
public class TransferlerApiController : ControllerBase
{
    private readonly BankaIslemServisi _banka;
    private readonly UserManager<Kullanici> _kullaniciYoneticisi;

    public TransferlerApiController(BankaIslemServisi banka, UserManager<Kullanici> kullaniciYoneticisi)
    {
        _banka = banka;
        _kullaniciYoneticisi = kullaniciYoneticisi;
    }

    private string KullaniciId => _kullaniciYoneticisi.GetUserId(User)!;

    [HttpPost]
    public async Task<ActionResult<TransferYaniti>> Gonder(TransferGirdisi girdi)
    {
        var kullaniciId = KullaniciId;
        var alicilar = await _banka.AlicilarAsync(kullaniciId);
        var alici = alicilar.FirstOrDefault(a => a.Id == girdi.KayitliAliciId);
        if (alici is null)
            return BadRequest(new { mesaj = "Bu kişi kayıtlı alıcılarınız arasında yok." });

        // Bakiye + günlük limit kontrolü (asistanla aynı kurallar)
        var kontrol = await _banka.TransferKontrolEtAsync(kullaniciId, girdi.Tutar, alici.TakmaAd, alicilar);
        if (!kontrol.Basarili)
            return BadRequest(new { mesaj = kontrol.Mesaj });

        var yeniBakiye = await _banka.TransferYapAsync(kontrol.Transfer!, IslemKanali.Web, girdi.Aciklama);
        return Ok(new TransferYaniti { Mesaj = "Para gönderildi.", YeniBakiye = yeniBakiye });
    }
}