using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Sesparator.Web.Models;

public class Hesap
{
    public int Id { get; set; }

    [Required, StringLength(26)]
    public string Iban { get; set; } = string.Empty;

    public HesapTuru HesapTuru { get; set; }

    [Required, StringLength(3)]
    public string ParaBirimi { get; set; } = "TRY";

    [Precision(18, 2)]
    public decimal Bakiye { get; set; }

    [Required]
    public string KullaniciId { get; set; } = string.Empty;
    public Kullanici? Kullanici { get; set; }

    public List<Islem> Islemler { get; set; } = new();
}
