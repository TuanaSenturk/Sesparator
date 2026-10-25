using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Sesparator.Web.Models;

public class Kart
{
    public int Id { get; set; }

    [Required, StringLength(19)]
    public string MaskeliKartNo { get; set; } = string.Empty;

    [Precision(18, 2)]
    public decimal Limit { get; set; }

    [Precision(18, 2)]
    public decimal Borc { get; set; }

    public DateTime SonOdemeTarihi { get; set; }

    [Required]
    public string KullaniciId { get; set; } = string.Empty;
    public Kullanici? Kullanici { get; set; }
}
