using System.ComponentModel.DataAnnotations;

namespace Sesparator.Web.Models;

public class KayitliAlici
{
    public int Id { get; set; }

    [Required, StringLength(30)]
    public string TakmaAd { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string AdSoyad { get; set; } = string.Empty;

    [Required, StringLength(26)]
    public string Iban { get; set; } = string.Empty;

    [Required]
    public string KullaniciId { get; set; } = string.Empty;
    public Kullanici? Kullanici { get; set; }
}
