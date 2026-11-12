using System.ComponentModel.DataAnnotations;

namespace Sesparator.Web.Models.Api;

// Gemini'nin seçebileceği niyetler. Cevat 6-7. haftada buraya yenilerini ekleyecek.
public static class Niyetler
{
    public const string BakiyeSorgula = "BAKIYE_SORGULA";
    public const string ParaTransferi = "PARA_TRANSFERI";
    public const string Bilinmiyor = "BILINMIYOR";

    public static readonly string[] Tumu = [BakiyeSorgula, ParaTransferi, Bilinmiyor];

    // Onay/iptal cevapları Gemini'ye gitmeden sunucuda yakalanır (AsistanServisi).
    // Bu yüzden Tumu dizisinde YOK: Tumu, Gemini'ye izin verilen niyet listesi olarak gidiyor.
    public const string Onay = "ONAY";
    public const string Iptal = "IPTAL";
}

// İstemci -> sunucu   JSON: { "metin": "Anneme 500 lira gönder" }
public class AsistanIstegi
{
    [Required, MaxLength(1000)] //SeseCevirIstegi sınıfıyla aynı kural
    public string Metin { get; set; } = string.Empty;
}

// Gemini'nin cevabı
public class NiyetSonucu
{
    public string Niyet { get; set; } = Niyetler.Bilinmiyor;
    public decimal? Tutar { get; set; }
    public string? AliciTakmaAd { get; set; }
}

// Onay bekleyen transfer ( onay akışı bunu kullanacak)
public class BekleyenTransfer
{
    public int HesapId { get; set; }
    public int KayitliAliciId { get; set; }
    public string AliciAdSoyad { get; set; } = string.Empty;
    public string AliciIban { get; set; } = string.Empty;
    public decimal Tutar { get; set; }
}

// Kontrolün sonucu: ya hata mesajı ya da hazır transfer
public class TransferKontrolSonucu
{
    public bool Basarili { get; init; }
    public string Mesaj { get; init; } = string.Empty;
    public BekleyenTransfer? Transfer { get; init; }

    public static TransferKontrolSonucu Hata(string mesaj) => new() { Basarili = false, Mesaj = mesaj };
    public static TransferKontrolSonucu Tamam(BekleyenTransfer t) => new() { Basarili = true, Transfer = t };
}

// Onaylanan transferin gerçekleştirilme sonucu
public class TransferSonucu
{
    public bool Basarili { get; init; }
    public string Mesaj { get; init; } = string.Empty;
}

// Sunucu -> istemci
public class AsistanYaniti
{
    public string Mesaj { get; set; } = string.Empty;
    public string Niyet { get; set; } = string.Empty;
    public bool OnayGerekli { get; set; }
    public BekleyenTransfer? BekleyenTransfer { get; set; }

    // Onay bekleyen işlemin Islemler tablosundaki Id'si (mobil, bekleyen işlemi göstermek için kullanabilir)
    public int? IslemId { get; set; }
}