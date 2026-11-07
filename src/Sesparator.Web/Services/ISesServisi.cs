namespace Sesparator.Web.Services;

// Ses <-> metin dönüşümü. Controller sadece bu arayüzü bilir;
// servis değişirse (ör. Azure) Program.cs'teki kayıt değişir, controller değişmez.
public interface ISesServisi
{
    // Konuşma algılanmazsa null döner
    Task<string?> MetneCevirAsync(byte[] ses, string icerikTuru);

    Task<(byte[] Ses, string IcerikTuru)> SeseCevirAsync(string metin);
}

// Modelin günlük/dakikalık kotası dolduğunda fırlatılır; API 429 döndürür.
public class KotaTukendiException : Exception
{
    public KotaTukendiException(string mesaj) : base(mesaj) { }
}
