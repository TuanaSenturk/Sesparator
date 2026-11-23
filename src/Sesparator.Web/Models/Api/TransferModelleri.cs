using System.ComponentModel.DataAnnotations;

namespace Sesparator.Web.Models.Api;

public class TransferGirdisi
{
    [Required]
    public int KayitliAliciId { get; set; }

    [Range(0.01, 1_000_000, ErrorMessage = "Geçerli bir tutar girin.")]
    public decimal Tutar { get; set; }

    [StringLength(100)]
    public string? Aciklama { get; set; }
}

public class TransferYaniti
{
    public string Mesaj { get; set; } = "";
}