using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Sesparator.Web.Helpers;

public static class IbanYardimcisi
{
    // Boşluklu ve küçük "tr" ile yazılmış IBAN'ı da kabul eder
    public const string BicimDeseni = @"^\s*[Tt][Rr]\s*([0-9]\s*){24}$";

    // "tr75 0006 ..." -> "TR750006..."
    public static string Normallestir(string? iban) =>
        string.Concat((iban ?? string.Empty).Where(c => !char.IsWhiteSpace(c))).ToUpperInvariant();

    public static bool BicimUygunMu(string? iban) =>
        Regex.IsMatch(Normallestir(iban), "^TR[0-9]{24}$");

    // ISO 13616 mod 97 kontrolü
    public static bool KontrolBasamagiDogruMu(string iban)
    {
        var temiz = Normallestir(iban);
        var duzenli = temiz[4..] + temiz[..4];

        var kalan = 0;
        foreach (var karakter in duzenli)
        {
            var sayi = char.IsAsciiDigit(karakter)
                ? (karakter - '0').ToString()
                : (karakter - 'A' + 10).ToString();

            foreach (var basamak in sayi)
                kalan = (kalan * 10 + (basamak - '0')) % 97;
        }
        return kalan == 1;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class TurkIbanAttribute : ValidationAttribute
{
    public TurkIbanAttribute() : base("IBAN hatalı görünüyor, lütfen rakamları kontrol edin.") { }

    public override bool IsValid(object? value)
    {
        if (value is not string iban || !IbanYardimcisi.BicimUygunMu(iban))
            return true;   // biçim hatasını [RegularExpression] yakalar
        return IbanYardimcisi.KontrolBasamagiDogruMu(iban);
    }
}
/* BicimDeseni: “TR + 24 rakam” kuralının regex hâli. Aynı desen tarayıcıda da çalışır, böylece kullanıcı formu göndermeden
 hatayı görür.
   Normallestir: Kullanıcı “tr75 0006 ...” diye boşluklu yazsa bile veritabanına “TR750006...” şeklinde tek biçimde kaydedil-
mesini sağlar.
   KontrolBasamagiDogruMu: IBAN’daki 2 kontrol hanesini (TR’den sonraki iki rakam) doğrular. Tek rakam yanlış yazılırsa sonuç 
tutmaz, böylece yanlış kişiye para gönderilmesinin önüne geçilir. Projedeki örnek veriler (OrnekVeriler.IbanOlustur) de aynı 
kuralla üretiliyor.
   TurkIbanAttribute: Bu kontrolü [TurkIban] yazarak bir özelliğe ekleyebilmeni sağlar. Biçim yanlışsa true döner, çünkü o 
hatayı zaten regex bildiriyor. Böylece aynı alan için iki ayrı hata mesajı çıkmaz.
*/