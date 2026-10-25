using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Sesparator.Web.Models;

public class Islem
{
    public int Id { get; set; }

    public IslemTuru IslemTuru { get; set; }

    [Precision(18, 2)]
    public decimal Tutar { get; set; }

    [StringLength(26)]
    public string? AliciIban { get; set; }

    [StringLength(200)]
    public string? Aciklama { get; set; }

    public DateTime Tarih { get; set; }

    public IslemKanali Kanal { get; set; }

    public IslemDurumu Durum { get; set; }

    public int HesapId { get; set; }
    public Hesap? Hesap { get; set; }
}
