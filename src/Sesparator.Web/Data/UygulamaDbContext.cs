using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sesparator.Web.Models;

namespace Sesparator.Web.Data;

public class UygulamaDbContext : IdentityDbContext<Kullanici>
{
    public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Hesap> Hesaplar { get; set; }
    public DbSet<Islem> Islemler { get; set; }
    public DbSet<KayitliAlici> KayitliAlicilar { get; set; }
    public DbSet<Kart> Kartlar { get; set; }
    public DbSet<AsistanLogu> AsistanLoglari { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        IdentityTablolariniTurkcelestir(builder);

        builder.Entity<Hesap>()
            .HasIndex(h => h.Iban)
            .IsUnique();

        builder.Entity<KayitliAlici>()
            .HasIndex(k => new { k.KullaniciId, k.TakmaAd })
            .IsUnique();

        builder.Entity<Hesap>()
            .HasOne(h => h.Kullanici)
            .WithMany(k => k.Hesaplar)
            .HasForeignKey(h => h.KullaniciId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Islem>()
            .HasOne(i => i.Hesap)
            .WithMany(h => h.Islemler)
            .HasForeignKey(i => i.HesapId)
            .OnDelete(DeleteBehavior.Restrict);

        OrnekVerileriEkle(builder);
    }

    private static void OrnekVerileriEkle(ModelBuilder builder)
    {
        var veriler = OrnekVeriler.Olustur();

        builder.Entity<IdentityRole>().HasData(veriler.Roller);
        builder.Entity<Kullanici>().HasData(veriler.Kullanicilar);
        builder.Entity<IdentityUserRole<string>>().HasData(veriler.KullaniciRolleri);
        builder.Entity<Hesap>().HasData(veriler.Hesaplar);
        builder.Entity<Islem>().HasData(veriler.Islemler);
        builder.Entity<Kart>().HasData(veriler.Kartlar);
        builder.Entity<KayitliAlici>().HasData(veriler.KayitliAlicilar);
    }

    private static void IdentityTablolariniTurkcelestir(ModelBuilder builder)
    {
        builder.Entity<Kullanici>(b =>
        {
            b.ToTable("Kullanicilar");
            b.Property(k => k.UserName).HasColumnName("KullaniciAdi");
            b.Property(k => k.NormalizedUserName).HasColumnName("NormalizeKullaniciAdi");
            b.Property(k => k.Email).HasColumnName("Eposta");
            b.Property(k => k.NormalizedEmail).HasColumnName("NormalizeEposta");
            b.Property(k => k.EmailConfirmed).HasColumnName("EpostaOnaylandi");
            b.Property(k => k.PasswordHash).HasColumnName("SifreOzeti");
            b.Property(k => k.SecurityStamp).HasColumnName("GuvenlikDamgasi");
            b.Property(k => k.ConcurrencyStamp).HasColumnName("EsZamanlilikDamgasi");
            b.Property(k => k.PhoneNumber).HasColumnName("TelefonNo");
            b.Property(k => k.PhoneNumberConfirmed).HasColumnName("TelefonOnaylandi");
            b.Property(k => k.TwoFactorEnabled).HasColumnName("IkiAdimliDogrulamaAcik");
            b.Property(k => k.LockoutEnd).HasColumnName("KilitBitisTarihi");
            b.Property(k => k.LockoutEnabled).HasColumnName("KilitlemeAcik");
            b.Property(k => k.AccessFailedCount).HasColumnName("HataliGirisSayisi");
            b.HasIndex(k => k.NormalizedUserName).HasDatabaseName("KullaniciAdiIndeksi");
            b.HasIndex(k => k.NormalizedEmail).HasDatabaseName("EpostaIndeksi");
        });

        builder.Entity<IdentityRole>(b =>
        {
            b.ToTable("Roller");
            b.Property(r => r.Name).HasColumnName("Ad");
            b.Property(r => r.NormalizedName).HasColumnName("NormalizeAd");
            b.Property(r => r.ConcurrencyStamp).HasColumnName("EsZamanlilikDamgasi");
            b.HasIndex(r => r.NormalizedName).HasDatabaseName("RolAdiIndeksi");
        });

        builder.Entity<IdentityUserRole<string>>(b =>
        {
            b.ToTable("KullaniciRolleri");
            b.Property(kr => kr.UserId).HasColumnName("KullaniciId");
            b.Property(kr => kr.RoleId).HasColumnName("RolId");
        });

        builder.Entity<IdentityUserClaim<string>>(b =>
        {
            b.ToTable("KullaniciYetkileri");
            b.Property(ky => ky.UserId).HasColumnName("KullaniciId");
            b.Property(ky => ky.ClaimType).HasColumnName("YetkiTuru");
            b.Property(ky => ky.ClaimValue).HasColumnName("YetkiDegeri");
        });

        builder.Entity<IdentityRoleClaim<string>>(b =>
        {
            b.ToTable("RolYetkileri");
            b.Property(ry => ry.RoleId).HasColumnName("RolId");
            b.Property(ry => ry.ClaimType).HasColumnName("YetkiTuru");
            b.Property(ry => ry.ClaimValue).HasColumnName("YetkiDegeri");
        });

        builder.Entity<IdentityUserLogin<string>>(b =>
        {
            b.ToTable("KullaniciDisGirisleri");
            b.Property(kg => kg.LoginProvider).HasColumnName("Saglayici");
            b.Property(kg => kg.ProviderKey).HasColumnName("SaglayiciAnahtari");
            b.Property(kg => kg.ProviderDisplayName).HasColumnName("SaglayiciGorunenAd");
            b.Property(kg => kg.UserId).HasColumnName("KullaniciId");
        });

        builder.Entity<IdentityUserToken<string>>(b =>
        {
            b.ToTable("KullaniciAnahtarlari");
            b.Property(ka => ka.UserId).HasColumnName("KullaniciId");
            b.Property(ka => ka.LoginProvider).HasColumnName("Saglayici");
            b.Property(ka => ka.Name).HasColumnName("Ad");
            b.Property(ka => ka.Value).HasColumnName("Deger");
        });
    }
}
