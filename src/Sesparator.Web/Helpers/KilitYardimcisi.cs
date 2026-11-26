namespace Sesparator.Web.Helpers;

// Yönetici kilidi ile hatalı denemelerden gelen 5 dakikalık kilidi ayırt eder.
// İkisi de Identity'nin LockoutEnd alanını kullanır; yönetici kilidi 100 yıl sonrasına kurulur.
public static class KilitYardimcisi
{
    // DateTimeOffset.MaxValue yerine 100 yıl: üstüne süre eklenen bir yerde taşma olmasın
    public static DateTimeOffset YoneticiKilidiBitisi() => DateTimeOffset.UtcNow.AddYears(100);

    // 1 yıldan uzak bir kilit, hatalı deneme kilidi olamaz
    public static bool YoneticiKilidiMi(DateTimeOffset? kilitBitisi) =>
        kilitBitisi.HasValue && kilitBitisi.Value > DateTimeOffset.UtcNow.AddYears(1);

    public const string YoneticiKilidiMesaji = "Hesabınız yönetici tarafından kilitlendi.";
}
