using System.Numerics;
using Microsoft.AspNetCore.Identity;
using Sesparator.Web.Models;

namespace Sesparator.Web.Data;

// Örnek veriler HasData ile migration'a yazılır. Rastgele değerler sabit bir tohumla üretilir;
// böylece her çalıştırmada aynı veriler çıkar ve EF her seferinde "veri değişti" sanmaz.
public class OrnekVeriler
{
    // PasswordHasher ile "Test123!" şifresinden bir kez üretildi.
    private const string TestSifreOzeti =
        "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==";

    // Gerçek bir bankaya ait olmayan hayali banka kodu.
    private const string BankaKodu = "00999";

    private const string EpostaUzantisi = "@sesparator.test";
    private const int EnFazlaKayitliAlici = 4;

    private static readonly DateTime HesapAcilisTarihi = new(2026, 8, 1, 9, 0, 0);
    private static readonly DateTime IlkSonOdemeTarihi = new(2026, 11, 1);

    public const string MusteriRolId = "00000000-0000-0000-0003-000000000001";
    public const string YoneticiRolId = "00000000-0000-0000-0003-000000000002";

    public List<IdentityRole> Roller { get; } = new();
    public List<Kullanici> Kullanicilar { get; } = new();
    public List<IdentityUserRole<string>> KullaniciRolleri { get; } = new();
    public List<Hesap> Hesaplar { get; } = new();
    public List<Islem> Islemler { get; } = new();
    public List<Kart> Kartlar { get; } = new();
    public List<KayitliAlici> KayitliAlicilar { get; } = new();

    private readonly Random _rastgele = new(2026);
    private readonly List<Musteri> _musteriler = new();
    private int _sonHesapId;
    private int _sonIslemId;
    private int _sonKartId;
    private int _sonKayitliAliciId;

    private OrnekVeriler()
    {
        RolleriEkle();
        YoneticiyiEkle();
        MusterileriEkle();
        KartBorcuOdemeleriniEkle();
        KayitliAlicilariEkle();
    }

    public static OrnekVeriler Olustur() => new();

    private void RolleriEkle()
    {
        Roller.Add(new IdentityRole
        {
            Id = MusteriRolId,
            Name = "Musteri",
            NormalizedName = "MUSTERI",
            ConcurrencyStamp = "b1f6a3e2-0c4d-4f6e-9a51-3d2c7e8f0a11"
        });
        Roller.Add(new IdentityRole
        {
            Id = YoneticiRolId,
            Name = "Yonetici",
            NormalizedName = "YONETICI",
            ConcurrencyStamp = "c2e7b4f3-1d5e-4a7f-8b62-4e3d8f9a1b22"
        });
    }

    private void YoneticiyiEkle()
    {
        var yonetici = KullaniciOlustur(
            "00000000-0000-0000-0002-000000000001", "Sistem", "Yöneticisi", "yonetici" + EpostaUzantisi);
        Kullanicilar.Add(yonetici);
        KullaniciRolleri.Add(new IdentityUserRole<string> { UserId = yonetici.Id, RoleId = YoneticiRolId });
    }

    private void MusterileriEkle()
    {
        var musteriNo = 0;
        for (var aileNo = 0; aileNo < Aileler.Length; aileNo++)
        {
            var aile = Aileler[aileNo];
            foreach (var uye in aile.Uyeler)
            {
                musteriNo++;
                var eposta = $"{AsciiYap(uye.Ad)}.{AsciiYap(aile.Soyad)}{EpostaUzantisi}";
                var kullanici = KullaniciOlustur(
                    $"00000000-0000-0000-0001-{musteriNo:D12}", uye.Ad, aile.Soyad, eposta);
                Kullanicilar.Add(kullanici);
                KullaniciRolleri.Add(new IdentityUserRole<string> { UserId = kullanici.Id, RoleId = MusteriRolId });

                var vadesiz = HesapOlustur(kullanici.Id, musteriNo, 1, HesapTuru.Vadesiz);
                HesapOlustur(kullanici.Id, musteriNo, 2, HesapTuru.Vadeli);

                var kart = new Kart
                {
                    Id = ++_sonKartId,
                    MaskeliKartNo = $"5412 **** **** {_rastgele.Next(0, 10000):D4}",
                    Limit = _rastgele.Next(2, 16) * 5000m,
                    SonOdemeTarihi = IlkSonOdemeTarihi.AddDays(_rastgele.Next(0, 30)),
                    KullaniciId = kullanici.Id
                };
                // Borç, limitin %0-60'ı arasında ve 50 TL'nin katı.
                kart.Borc = _rastgele.Next(0, (int)(kart.Limit * 0.6m / 50) + 1) * 50m;
                Kartlar.Add(kart);

                _musteriler.Add(new Musteri(kullanici, vadesiz, kart, aileNo, uye));
            }
        }
    }

    private Hesap HesapOlustur(string kullaniciId, int musteriNo, int hesapSirasi, HesapTuru tur)
    {
        var hesapNo = $"{_rastgele.Next(1000, 10000)}{musteriNo:D4}{hesapSirasi:D2}{_rastgele.Next(100000, 1000000)}";
        var baslangicParasi = _rastgele.Next(10, 301) * 500m;

        var hesap = new Hesap
        {
            Id = ++_sonHesapId,
            Iban = IbanOlustur(hesapNo),
            HesapTuru = tur,
            ParaBirimi = "TRY",
            Bakiye = baslangicParasi,
            KullaniciId = kullaniciId
        };
        Hesaplar.Add(hesap);

        Islemler.Add(new Islem
        {
            Id = ++_sonIslemId,
            IslemTuru = IslemTuru.GelenTransfer,
            Tutar = baslangicParasi,
            AliciIban = null,
            Aciklama = "Başlangıç parası",
            Tarih = HesapAcilisTarihi,
            Kanal = IslemKanali.Web,
            Durum = IslemDurumu.Tamamlandi,
            HesapId = hesap.Id
        });

        return hesap;
    }

    // Rastgele seçilen müşterilerin yarısı, 2 Ağustos - 24 Ekim arasında vadesiz hesabından 1-2 kez kart borcu öder.
    private void KartBorcuOdemeleriniEkle()
    {
        var odeyenler = _musteriler
            .OrderBy(_ => _rastgele.Next())
            .Take(_musteriler.Count / 2)
            .ToHashSet();

        foreach (var musteri in _musteriler.Where(odeyenler.Contains))
        {
            var odemeTarihleri = Enumerable.Range(0, _rastgele.Next(1, 3))
                .Select(_ => HesapAcilisTarihi.Date.AddDays(1 + _rastgele.Next(0, 84)).AddHours(_rastgele.Next(9, 22)))
                .OrderBy(t => t)
                .ToList();

            foreach (var tarih in odemeTarihleri)
            {
                var tutar = Math.Min(_rastgele.Next(10, 101) * 50m, musteri.Vadesiz.Bakiye);
                musteri.Vadesiz.Bakiye -= tutar;

                Islemler.Add(new Islem
                {
                    Id = ++_sonIslemId,
                    IslemTuru = IslemTuru.KartBorcOdeme,
                    Tutar = tutar,
                    AliciIban = null,
                    Aciklama = $"Kart borcu ödemesi ({musteri.Kart.MaskeliKartNo})",
                    Tarih = tarih,
                    Kanal = IslemKanali.Web,
                    Durum = IslemDurumu.Tamamlandi,
                    HesapId = musteri.Vadesiz.Id
                });
            }
        }
    }

    // Kayıtlı alıcılar önce aile içinden, yer kalırsa başka ailelerdeki arkadaşlardan seçilir.
    // Hepsi sistemdeki müşterilerin vadesiz hesaplarını gösterir.
    private void KayitliAlicilariEkle()
    {
        foreach (var musteri in _musteriler)
        {
            var adaylar = AileIciAdaylar(musteri);
            foreach (var arkadas in Arkadaslar(musteri))
            {
                var takmaAd = adaylar.Any(a => a.TakmaAd == arkadas.Uye.Ad)
                    ? $"{arkadas.Kullanici.Ad} {arkadas.Kullanici.Soyad}"
                    : arkadas.Uye.Ad;
                adaylar.Add((takmaAd, arkadas));
            }

            foreach (var (takmaAd, hedef) in adaylar.Take(EnFazlaKayitliAlici))
            {
                KayitliAlicilar.Add(new KayitliAlici
                {
                    Id = ++_sonKayitliAliciId,
                    TakmaAd = takmaAd,
                    AdSoyad = $"{hedef.Kullanici.Ad} {hedef.Kullanici.Soyad}",
                    Iban = hedef.Vadesiz.Iban,
                    KullaniciId = musteri.Kullanici.Id
                });
            }
        }
    }

    private List<(string TakmaAd, Musteri Hedef)> AileIciAdaylar(Musteri musteri)
    {
        var aile = _musteriler.Where(m => m.AileNo == musteri.AileNo && m != musteri).ToList();
        var cocuklar = _musteriler.Where(m => m.AileNo == musteri.AileNo && m.Uye.Rol == AileRolu.Cocuk).ToList();
        var adaylar = new List<(string TakmaAd, Musteri Hedef)>();

        if (musteri.Uye.Rol == AileRolu.Cocuk)
        {
            adaylar.Add(("Annem", aile.Single(m => m.Uye.Rol == AileRolu.Anne)));
            adaylar.Add(("Babam", aile.Single(m => m.Uye.Rol == AileRolu.Baba)));

            var sira = cocuklar.IndexOf(musteri);
            foreach (var kardes in cocuklar.Where(c => c != musteri))
            {
                var buyuk = cocuklar.IndexOf(kardes) < sira;
                var etiket = buyuk ? (kardes.Uye.Kadin ? "Ablam" : "Abim") : "Kardeşim";
                adaylar.Add((etiket, kardes));
            }
        }
        else
        {
            adaylar.Add(("Eşim", aile.Single(m => m.Uye.Rol is AileRolu.Anne or AileRolu.Baba)));
            foreach (var cocuk in cocuklar)
            {
                adaylar.Add((cocuk.Uye.Kadin ? "Kızım" : "Oğlum", cocuk));
            }
        }

        // Aynı etiket birden fazla kişiye düşerse ("Kızım" gibi) sonuna ad eklenir: "Kızım Elif".
        var tekrarlananlar = adaylar.GroupBy(a => a.TakmaAd).Where(g => g.Count() > 1).Select(g => g.Key).ToHashSet();
        return adaylar
            .Select(a => tekrarlananlar.Contains(a.TakmaAd) ? ($"{a.TakmaAd} {a.Hedef.Uye.Ad}", a.Hedef) : a)
            .ToList();
    }

    // Anneler bir sonraki ailenin annesiyle, babalar iki sonraki ailenin babasıyla,
    // ilk çocuklar da bir sonraki ailenin ilk çocuğuyla arkadaştır (ilişki iki yönlüdür).
    private IEnumerable<Musteri> Arkadaslar(Musteri musteri)
    {
        var (rol, aralik) = musteri.Uye.Rol switch
        {
            AileRolu.Anne => (AileRolu.Anne, 1),
            AileRolu.Baba => (AileRolu.Baba, 2),
            _ => (AileRolu.Cocuk, 1)
        };

        if (rol == AileRolu.Cocuk && IlkCocuk(musteri.AileNo) != musteri)
        {
            yield break;
        }

        foreach (var digerAile in new[] { musteri.AileNo + aralik, musteri.AileNo - aralik })
        {
            var aileNo = (digerAile + Aileler.Length) % Aileler.Length;
            yield return rol == AileRolu.Cocuk
                ? IlkCocuk(aileNo)
                : _musteriler.Single(m => m.AileNo == aileNo && m.Uye.Rol == rol);
        }
    }

    private Musteri IlkCocuk(int aileNo) =>
        _musteriler.First(m => m.AileNo == aileNo && m.Uye.Rol == AileRolu.Cocuk);

    private Kullanici KullaniciOlustur(string id, string ad, string soyad, string eposta) => new()
    {
        Id = id,
        Ad = ad,
        Soyad = soyad,
        UserName = eposta,
        NormalizedUserName = eposta.ToUpperInvariant(),
        Email = eposta,
        NormalizedEmail = eposta.ToUpperInvariant(),
        EmailConfirmed = true,
        PasswordHash = TestSifreOzeti,
        SecurityStamp = RastgeleGuid(),
        ConcurrencyStamp = RastgeleGuid(),
        LockoutEnabled = true
    };

    private string RastgeleGuid()
    {
        var baytlar = new byte[16];
        _rastgele.NextBytes(baytlar);
        return new Guid(baytlar).ToString();
    }

    // TR + 2 kontrol basamağı + 5 haneli banka kodu + 1 rezerv hane (0) + 16 haneli hesap no.
    // Kontrol basamağı ISO 13616 (mod 97) kuralıyla hesaplanır; T=29, R=27.
    private static string IbanOlustur(string hesapNo)
    {
        var bban = BankaKodu + "0" + hesapNo;
        var kalan = (int)(BigInteger.Parse(bban + "292700") % 97);
        return $"TR{98 - kalan:D2}{bban}";
    }

    private static string AsciiYap(string metin) => new(metin.Select(c => c switch
    {
        'ç' or 'Ç' => 'c',
        'ğ' or 'Ğ' => 'g',
        'ı' or 'I' or 'İ' => 'i',
        'ö' or 'Ö' => 'o',
        'ş' or 'Ş' => 's',
        'ü' or 'Ü' => 'u',
        _ => char.ToLowerInvariant(c)
    }).ToArray());

    private enum AileRolu
    {
        Anne,
        Baba,
        Cocuk
    }

    private record AileUyesi(string Ad, bool Kadin, AileRolu Rol);

    private record Aile(string Soyad, params AileUyesi[] Uyeler);

    private record Musteri(Kullanici Kullanici, Hesap Vadesiz, Kart Kart, int AileNo, AileUyesi Uye);

    private static AileUyesi Anne(string ad) => new(ad, true, AileRolu.Anne);
    private static AileUyesi Baba(string ad) => new(ad, false, AileRolu.Baba);
    private static AileUyesi Kiz(string ad) => new(ad, true, AileRolu.Cocuk);
    private static AileUyesi Ogul(string ad) => new(ad, false, AileRolu.Cocuk);

    // 14 aile, toplam 50 müşteri. Çocuklar büyükten küçüğe sıralıdır.
    private static readonly Aile[] Aileler =
    {
        new("Yılmaz", Anne("Fatma"), Baba("Mustafa"), Kiz("Ayşe"), Ogul("Emre")),
        new("Kaya", Anne("Hatice"), Baba("Mehmet"), Kiz("Zeynep"), Ogul("Burak"), Kiz("Elif")),
        new("Demir", Anne("Emine"), Baba("Ahmet"), Ogul("Can")),
        new("Şahin", Anne("Ayten"), Baba("Hüseyin"), Kiz("Merve"), Kiz("Selin")),
        new("Çelik", Anne("Zehra"), Baba("İbrahim"), Ogul("Oğuz")),
        new("Yıldız", Anne("Sevgi"), Baba("Ali"), Kiz("Deniz"), Ogul("Kerem")),
        new("Yıldırım", Anne("Gülsüm"), Baba("Hasan"), Kiz("Ece")),
        new("Öztürk", Anne("Nermin"), Baba("Osman"), Ogul("Berk"), Kiz("İrem")),
        new("Aydın", Anne("Leyla"), Baba("Murat"), Ogul("Cem")),
        new("Özdemir", Anne("Meltem"), Baba("Serkan"), Kiz("Defne"), Ogul("Arda")),
        new("Arslan", Anne("Sibel"), Baba("Kemal"), Kiz("Gizem")),
        new("Doğan", Anne("Filiz"), Baba("Yusuf"), Ogul("Ozan"), Kiz("Buse")),
        new("Kılıç", Anne("Esra"), Baba("Tolga"), Ogul("Mert")),
        new("Koç", Anne("Derya"), Baba("Volkan"), Kiz("Ada"))
    };
}
