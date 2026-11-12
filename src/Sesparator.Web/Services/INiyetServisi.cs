using Sesparator.Web.Models.Api;

namespace Sesparator.Web.Services;

// Kullanıcının cümlesinden "ne istiyor?" bilgisini çıkarır.
// Gemini yerine başka model kullanılırsa sadece Program.cs'teki kayıt değişir.
public interface INiyetServisi
{
    Task<NiyetSonucu> NiyetCikarAsync(string metin, IReadOnlyList<string> takmaAdlar);
}