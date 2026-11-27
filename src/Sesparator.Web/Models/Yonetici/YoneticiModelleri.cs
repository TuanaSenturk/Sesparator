namespace Sesparator.Web.Models.Yonetici;

// Panel ana sayfasındaki özet kartları
public class YoneticiOzetModeli
{
    public int MusteriSayisi { get; init; }
    public int BugunkuIslemSayisi { get; init; }
    public int BugunkuSesliIslemSayisi { get; init; }
    public int BekleyenIslemSayisi { get; init; }
}

// Kullanıcılar listesindeki bir satır
public class KullaniciSatiri
{
    public string Id { get; init; } = "";
    public string AdSoyad { get; init; } = "";
    public string Eposta { get; init; } = "";
    public int HesapSayisi { get; init; }
    public decimal ToplamBakiye { get; init; }   // TRY hesapların toplamı
    public DateTimeOffset? KilitBitisi { get; init; }
}

public class KullaniciListesiModeli
{
    public string? Arama { get; init; }
    public List<KullaniciSatiri> Kullanicilar { get; init; } = [];
}

public class KullaniciDetayModeli
{
    public KullaniciSatiri Kullanici { get; init; } = new();
    public List<Hesap> Hesaplar { get; init; } = [];
    public List<IslemSatiri> SonIslemler { get; init; } = [];
}

// İşlem izleme sayfasındaki filtreler (GET formundan gelir, boş olanlar uygulanmaz)
public class IslemFiltresi
{
    public DateTime? BaslangicTarihi { get; set; }
    public DateTime? BitisTarihi { get; set; }
    public IslemKanali? Kanal { get; set; }
    public IslemDurumu? Durum { get; set; }
    public IslemTuru? Tur { get; set; }
    public int Sayfa { get; set; } = 1;

    // Sayfa linkleri filtreleri kaybetmesin
    public Dictionary<string, string> RotaDegerleri(int sayfa)
    {
        var degerler = new Dictionary<string, string> { [nameof(Sayfa)] = sayfa.ToString() };
        if (BaslangicTarihi is { } bas) degerler[nameof(BaslangicTarihi)] = bas.ToString("yyyy-MM-dd");
        if (BitisTarihi is { } bit) degerler[nameof(BitisTarihi)] = bit.ToString("yyyy-MM-dd");
        if (Kanal is { } kanal) degerler[nameof(Kanal)] = kanal.ToString();
        if (Durum is { } durum) degerler[nameof(Durum)] = durum.ToString();
        if (Tur is { } tur) degerler[nameof(Tur)] = tur.ToString();
        return degerler;
    }
}

// Yönetici tablolarında bir işlem (sadece gereken alanlar çekilir)
public class IslemSatiri
{
    public int Id { get; init; }
    public DateTime Tarih { get; init; }
    public string MusteriId { get; init; } = "";
    public string MusteriAdSoyad { get; init; } = "";
    public string HesapIban { get; init; } = "";
    public string ParaBirimi { get; init; } = "TRY";
    public IslemTuru IslemTuru { get; init; }
    public IslemKanali Kanal { get; init; }
    public IslemDurumu Durum { get; init; }
    public decimal Tutar { get; init; }
    public string? Aciklama { get; init; }
}

public class IslemIzlemeModeli
{
    public IslemFiltresi Filtre { get; init; } = new();
    public List<IslemSatiri> Islemler { get; init; } = [];
    public int ToplamKayit { get; init; }
    public int ToplamSayfa { get; init; }
}
