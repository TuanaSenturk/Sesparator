using System.ComponentModel.DataAnnotations;

namespace Sesparator.Web.Models;

public class GirisIstegi
{
    [Required, EmailAddress]
    public string Eposta { get; set; } = string.Empty;

    [Required]
    public string Sifre { get; set; } = string.Empty;
}

public record TokenYaniti(string Token, DateTime BitisZamani, string Ad, string Soyad, IList<string> Roller);