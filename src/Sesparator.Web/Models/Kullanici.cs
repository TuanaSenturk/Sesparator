using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Sesparator.Web.Models;

public class Kullanici : IdentityUser
{
    [Required, StringLength(50)]
    public string Ad { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string Soyad { get; set; } = string.Empty;

    public List<Hesap> Hesaplar { get; set; } = new();
    public List<KayitliAlici> KayitliAlicilar { get; set; } = new();
    public List<Kart> Kartlar { get; set; } = new();
    public List<AsistanLogu> AsistanLoglari { get; set; } = new();
}
