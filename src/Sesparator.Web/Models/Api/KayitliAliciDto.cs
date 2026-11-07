namespace Sesparator.Web.Models.Api;

// API'nin dışarıya döndürdüğü alıcı bilgisi
public record KayitliAliciDto(int Id, string TakmaAd, string AdSoyad, string Iban)
{
    public static KayitliAliciDto Olustur(KayitliAlici alici) =>
        new(alici.Id, alici.TakmaAd, alici.AdSoyad, alici.Iban);
}
/*
Ne işe yarar: Girdi sınıfı içeri gelen veriyi tanımlıyordu, DTO ise dışarı giden veriyi tanımlıyor. 
KullaniciId ve Kullanici alanları yanıtta yer almaz. Mobil uygulama sadece ihtiyaç duyduğu alanları alır. 
Cevat’ın yazdığı HesapDto da aynı mantıkla çalışıyor.
*/