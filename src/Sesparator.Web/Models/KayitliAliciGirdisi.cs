using System.ComponentModel.DataAnnotations;
using Sesparator.Web.Helpers;

namespace Sesparator.Web.Models;

// Hem web formu hem API bu sınıfı kullanır: kurallar tek yerde
public class KayitliAliciGirdisi
{
    [Required(ErrorMessage = "Takma ad zorunludur.")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Takma ad 2-30 karakter olmalıdır.")]
    [Display(Name = "Takma ad")]
    public string TakmaAd { get; set; } = string.Empty;

    [Required(ErrorMessage = "Alıcının adı soyadı zorunludur.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Ad soyad 3-100 karakter olmalıdır.")]
    [RegularExpression(@"^[a-zA-ZçÇğĞıİöÖşŞüÜ\s.'-]+$", ErrorMessage = "Ad soyad yalnızca harf içermelidir.")]
    [Display(Name = "Alıcının adı soyadı")]
    public string AdSoyad { get; set; } = string.Empty;

    [Required(ErrorMessage = "IBAN zorunludur.")]
    [RegularExpression(IbanYardimcisi.BicimDeseni, ErrorMessage = "IBAN, TR ile başlayıp 24 rakamla devam etmelidir.")]
    [TurkIban]
    [Display(Name = "IBAN")]
    public string Iban { get; set; } = string.Empty;

    // Doğrulama geçtikten sonra: boşlukları temizle, IBAN'ı tek biçime getir
    public void Temizle()
    {
        TakmaAd = TakmaAd.Trim();
        AdSoyad = AdSoyad.Trim();
        Iban = IbanYardimcisi.Normallestir(Iban);
    }
}

/*KayitliAlici: Veritabanı tablosunun C# karşılığı (entity).

Alanları: Id, TakmaAd, AdSoyad, Iban, KullaniciId, Kullanici
EF Core bu sınıfa bakarak tabloyu oluşturur, okuma ve yazma işlemlerini bu sınıf üzerinden yapar.
Kim kullanır: UygulamaDbContext, migration’lar.

KayitliAliciGirdisi: Kullanıcıdan gelen verinin kalıbı (input model).

Alanları: sadece TakmaAd, AdSoyad, Iban
Web formu ve API isteği bu sınıfa doldurulur ve doğrulama kuralları bu sınıfta durur.
Kim kullanır: controller’lar.

Neden ayrı bir sınıf gerekiyor?

Güvenlik (overposting): Formda veya API’de doğrudan KayitliAlici alırsan kullanıcı isteğe "kullaniciId": "baskasininId" ekleyip başkası adına alıcı oluşturabilir. Girdi sınıfında bu alan hiç olmadığı için böyle bir veri gönderilemez. KullaniciId değerini sunucu oturumdan kendisi alır.
Farklı kurallar: Kullanıcı IBAN’ı “tr75 0006 ...” diye boşluklu yazabilir, bu yüzden girdi sınıfı esnek. Veritabanında ise boşluksuz 26 karakter tutuluyor. Gelen veri doğrulanıp Temizle() ile düzeltildikten sonra KayitliAlici nesnesine aktarılıyor.
Bağımsızlık: Tabloya yeni bir sütun eklesen bile formun veya API’nin yapısı değişmez.
*/