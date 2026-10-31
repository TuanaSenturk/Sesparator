using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Sesparator.Web.Models;

namespace Sesparator.Web.Services;

public class JwtServisi
{
    private readonly IConfiguration _ayarlar;

    public JwtServisi(IConfiguration ayarlar)
    {
        _ayarlar = ayarlar;
    }

    public (string Token, DateTime BitisZamani) Olustur(Kullanici kullanici, IList<string> roller)
    {
        var jwt = _ayarlar.GetSection("Jwt");

        var talepler = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, kullanici.Id),
            new(ClaimTypes.Name, kullanici.UserName!),
            new(ClaimTypes.Email, kullanici.Email!),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        talepler.AddRange(roller.Select(r => new Claim(ClaimTypes.Role, r)));

        var anahtar = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Anahtar"]!));
        var bitis = DateTime.UtcNow.AddMinutes(jwt.GetValue("SureDakika", 60));

        var tanim = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(talepler),
            Issuer = jwt["Yayinci"],
            Audience = jwt["Hedef"],
            Expires = bitis,
            SigningCredentials = new SigningCredentials(anahtar, SecurityAlgorithms.HmacSha256)
        };

        return (new JsonWebTokenHandler().CreateToken(tanim), bitis);
    }
}