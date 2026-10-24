using System.ComponentModel.DataAnnotations;

namespace Sesparator.Web.Models;

public class AsistanLogu
{
    public int Id { get; set; }

    [Required, StringLength(500)]
    public string SoylenenMetin { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Niyet { get; set; }

    public string? IslemBilgisi { get; set; }

    [StringLength(500)]
    public string? Sonuc { get; set; }

    public DateTime Tarih { get; set; }

    [Required]
    public string KullaniciId { get; set; } = string.Empty;
    public Kullanici? Kullanici { get; set; }
}
