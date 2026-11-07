using System.ComponentModel.DataAnnotations;

namespace Sesparator.Web.Models.Api;

public class SeseCevirIstegi
{
    [Required, MaxLength(1000)]
    public string Metin { get; set; } = string.Empty;
}

// JSON'da: { "metin": "..." }
public record MetinYaniti(string Metin);
