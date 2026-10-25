using System.Globalization;
using Sesparator.Web.Models;

namespace Sesparator.Web.Helpers;

public static class Bicim
{
    private static readonly CultureInfo Tr = new("tr-TR");

    // TR820099902999000101813166 -> TR82 0099 9029 9900 0101 8131 66
    public static string Iban(string iban) =>
        string.Join(" ", iban.Chunk(4).Select(p => new string(p)));

    // 71900 -> 71.900,00 TL
    public static string Para(decimal tutar, string paraBirimi = "TRY") =>
        tutar.ToString("N2", Tr) + (paraBirimi == "TRY" ? " TL" : " " + paraBirimi);

    public static string HesapTuruAdi(HesapTuru tur) => tur switch
    {
        HesapTuru.Vadesiz => "Vadesiz",
        HesapTuru.Vadeli => "Vadeli",
        _ => tur.ToString()
    };

    public static string IslemTuruAdi(IslemTuru tur) => tur switch
    {
        IslemTuru.GidenTransfer => "Giden transfer",
        IslemTuru.GelenTransfer => "Gelen transfer",
        IslemTuru.KartBorcOdeme => "Kart borcu ödeme",
        _ => tur.ToString()
    };

    public static string DurumAdi(IslemDurumu durum) => durum switch
    {
        IslemDurumu.Beklemede => "Beklemede",
        IslemDurumu.Tamamlandi => "Tamamlandı",
        IslemDurumu.IptalEdildi => "İptal edildi",
        IslemDurumu.Basarisiz => "Başarısız",
        _ => durum.ToString()
    };

    public static string KanalAdi(IslemKanali kanal) => kanal switch
    {
        IslemKanali.Web => "Web",
        IslemKanali.Ses => "Sesli asistan",
        _ => kanal.ToString()
    };
}