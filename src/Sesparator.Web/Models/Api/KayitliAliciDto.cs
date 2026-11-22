namespace Sesparator.Web.Models.Api;

// API'nin dışarıya döndürdüğü alıcı bilgisi
public record KayitliAliciDto(int Id, string TakmaAd, string AdSoyad, string Iban)
{
    public static KayitliAliciDto Olustur(KayitliAlici alici) =>
        new(alici.Id, alici.TakmaAd, alici.AdSoyad, alici.Iban);
}
