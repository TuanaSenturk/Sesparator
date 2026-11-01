namespace Sesparator.Web.Models.Api;

// DTO (Data Transfer Object): API'nin dışarıya verdiği veri.
// Hesap modelini doğrudan döndürmüyoruz, çünkü içinde Kullanici ve Islemler ilişkileri var.
// Sadece mobilin ihtiyaç duyduğu alanları veriyoruz.
// JSON'da alan adları camelCase olur: id, iban, hesapTuru, paraBirimi, bakiye
public record HesapDto(int Id, string Iban, string HesapTuru, string ParaBirimi, decimal Bakiye);