using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sesparator.Web.Migrations
{
    /// <inheritdoc />
    public partial class IlkKurulum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizeKullaniciAdi = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizeEposta = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EpostaOnaylandi = table.Column<bool>(type: "bit", nullable: false),
                    SifreOzeti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuvenlikDamgasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsZamanlilikDamgasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonOnaylandi = table.Column<bool>(type: "bit", nullable: false),
                    IkiAdimliDogrulamaAcik = table.Column<bool>(type: "bit", nullable: false),
                    KilitBitisTarihi = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    KilitlemeAcik = table.Column<bool>(type: "bit", nullable: false),
                    HataliGirisSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizeAd = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EsZamanlilikDamgasi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AsistanLoglari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoylenenMetin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Niyet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IslemBilgisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sonuc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullaniciId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistanLoglari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsistanLoglari_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hesaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iban = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    HesapTuru = table.Column<int>(type: "int", nullable: false),
                    ParaBirimi = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Bakiye = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    KullaniciId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesaplar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hesaplar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kartlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaskeliKartNo = table.Column<string>(type: "nvarchar(19)", maxLength: 19, nullable: false),
                    Limit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Borc = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SonOdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullaniciId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kartlar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KayitliAlicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakmaAd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    KullaniciId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KayitliAlicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KayitliAlicilar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciAnahtarlari",
                columns: table => new
                {
                    KullaniciId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Saglayici = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Deger = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciAnahtarlari", x => new { x.KullaniciId, x.Saglayici, x.Ad });
                    table.ForeignKey(
                        name: "FK_KullaniciAnahtarlari_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciDisGirisleri",
                columns: table => new
                {
                    Saglayici = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SaglayiciAnahtari = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SaglayiciGorunenAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciDisGirisleri", x => new { x.Saglayici, x.SaglayiciAnahtari });
                    table.ForeignKey(
                        name: "FK_KullaniciDisGirisleri_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciYetkileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YetkiTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YetkiDegeri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciYetkileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciYetkileri_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRolleri",
                columns: table => new
                {
                    KullaniciId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RolId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRolleri", x => new { x.KullaniciId, x.RolId });
                    table.ForeignKey(
                        name: "FK_KullaniciRolleri_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciRolleri_Roller_RolId",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolYetkileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YetkiTuru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YetkiDegeri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolYetkileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolYetkileri_Roller_RolId",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Islemler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IslemTuru = table.Column<int>(type: "int", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AliciIban = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kanal = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    HesapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islemler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Islemler_Hesaplar_HesapId",
                        column: x => x.HesapId,
                        principalTable: "Hesaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsistanLoglari_KullaniciId",
                table: "AsistanLoglari",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Hesaplar_Iban",
                table: "Hesaplar",
                column: "Iban",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hesaplar_KullaniciId",
                table: "Hesaplar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Islemler_HesapId",
                table: "Islemler",
                column: "HesapId");

            migrationBuilder.CreateIndex(
                name: "IX_Kartlar_KullaniciId",
                table: "Kartlar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KayitliAlicilar_KullaniciId_TakmaAd",
                table: "KayitliAlicilar",
                columns: new[] { "KullaniciId", "TakmaAd" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciDisGirisleri_KullaniciId",
                table: "KullaniciDisGirisleri",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "EpostaIndeksi",
                table: "Kullanicilar",
                column: "NormalizeEposta");

            migrationBuilder.CreateIndex(
                name: "KullaniciAdiIndeksi",
                table: "Kullanicilar",
                column: "NormalizeKullaniciAdi",
                unique: true,
                filter: "[NormalizeKullaniciAdi] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRolleri_RolId",
                table: "KullaniciRolleri",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciYetkileri_KullaniciId",
                table: "KullaniciYetkileri",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "RolAdiIndeksi",
                table: "Roller",
                column: "NormalizeAd",
                unique: true,
                filter: "[NormalizeAd] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RolYetkileri_RolId",
                table: "RolYetkileri",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsistanLoglari");

            migrationBuilder.DropTable(
                name: "Islemler");

            migrationBuilder.DropTable(
                name: "Kartlar");

            migrationBuilder.DropTable(
                name: "KayitliAlicilar");

            migrationBuilder.DropTable(
                name: "KullaniciAnahtarlari");

            migrationBuilder.DropTable(
                name: "KullaniciDisGirisleri");

            migrationBuilder.DropTable(
                name: "KullaniciRolleri");

            migrationBuilder.DropTable(
                name: "KullaniciYetkileri");

            migrationBuilder.DropTable(
                name: "RolYetkileri");

            migrationBuilder.DropTable(
                name: "Hesaplar");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
