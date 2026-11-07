namespace Sesparator.Web.Models.Api;

// Hesap detayındaki bir işlem. Islem modelindeki Hesap ilişkisini dışarı vermiyoruz.
// Enum'lar metin olarak gider; JSON'da alan adları camelCase olur:
// id, islemTuru, tutar, aliciIban, aciklama, tarih, kanal, durum
public record IslemDto(
    int Id,
    string IslemTuru,
    decimal Tutar,
    string? AliciIban,
    string? Aciklama,
    DateTime Tarih,
    string Kanal,
    string Durum);