using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sesparator.Web.Migrations
{
    /// <inheritdoc />
    public partial class OrnekVeriler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "Id", "HataliGirisSayisi", "Ad", "EsZamanlilikDamgasi", "Eposta", "EpostaOnaylandi", "KilitlemeAcik", "KilitBitisTarihi", "NormalizeEposta", "NormalizeKullaniciAdi", "SifreOzeti", "TelefonNo", "TelefonOnaylandi", "GuvenlikDamgasi", "Soyad", "IkiAdimliDogrulamaAcik", "KullaniciAdi" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0001-000000000001", 0, "Fatma", "af4db169-daaf-0da5-f0a3-0c26d7e4e3b5", "fatma.yilmaz@sesparator.test", true, true, null, "FATMA.YILMAZ@SESPARATOR.TEST", "FATMA.YILMAZ@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "e1dd876d-4fdf-c2db-6119-1f7cab58ac4d", "Yılmaz", false, "fatma.yilmaz@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000002", 0, "Mustafa", "b4423cf0-7deb-6935-e718-62af34de7f2b", "mustafa.yilmaz@sesparator.test", true, true, null, "MUSTAFA.YILMAZ@SESPARATOR.TEST", "MUSTAFA.YILMAZ@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "2f5e4383-1816-659a-38c9-ca1dd292e1cf", "Yılmaz", false, "mustafa.yilmaz@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000003", 0, "Ayşe", "eab5fe48-5a30-9f49-17e4-3c7f212faf4d", "ayse.yilmaz@sesparator.test", true, true, null, "AYSE.YILMAZ@SESPARATOR.TEST", "AYSE.YILMAZ@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "77ea1aab-63c0-481a-99f5-e0f4d6060df5", "Yılmaz", false, "ayse.yilmaz@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000004", 0, "Emre", "9b26dc60-6a27-9246-cb5c-35f276d9a6b6", "emre.yilmaz@sesparator.test", true, true, null, "EMRE.YILMAZ@SESPARATOR.TEST", "EMRE.YILMAZ@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "114b8a44-4f17-b954-788d-3ea04051d14b", "Yılmaz", false, "emre.yilmaz@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000005", 0, "Hatice", "621abb46-9f42-88e7-4afc-3b12f75a0f3a", "hatice.kaya@sesparator.test", true, true, null, "HATICE.KAYA@SESPARATOR.TEST", "HATICE.KAYA@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "890e21b7-8038-334a-0e7b-d8fac4da43b9", "Kaya", false, "hatice.kaya@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000006", 0, "Mehmet", "37443c3e-b43b-9e6b-8905-271f36049665", "mehmet.kaya@sesparator.test", true, true, null, "MEHMET.KAYA@SESPARATOR.TEST", "MEHMET.KAYA@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "5bdd2bca-3b7f-9b7b-bf11-d2c725173a86", "Kaya", false, "mehmet.kaya@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000007", 0, "Zeynep", "5b147ad2-bb64-6d7a-0d26-427fdb4fc044", "zeynep.kaya@sesparator.test", true, true, null, "ZEYNEP.KAYA@SESPARATOR.TEST", "ZEYNEP.KAYA@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "a867fe9a-9b9a-fce9-03e7-70700716c03f", "Kaya", false, "zeynep.kaya@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000008", 0, "Burak", "6a58749b-b321-2b27-cf27-fc5308f11088", "burak.kaya@sesparator.test", true, true, null, "BURAK.KAYA@SESPARATOR.TEST", "BURAK.KAYA@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "4af4af01-bef7-6bfa-1c01-ec3bf7de83fa", "Kaya", false, "burak.kaya@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000009", 0, "Elif", "a7c2cf7a-2b62-63f0-15cb-24b881d845d4", "elif.kaya@sesparator.test", true, true, null, "ELIF.KAYA@SESPARATOR.TEST", "ELIF.KAYA@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "6558bf32-3ae8-3ce8-45f5-33cb174e88c9", "Kaya", false, "elif.kaya@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000010", 0, "Emine", "30161d4f-6dba-5eaf-e565-cd20f5109000", "emine.demir@sesparator.test", true, true, null, "EMINE.DEMIR@SESPARATOR.TEST", "EMINE.DEMIR@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "5a541aac-6c14-af42-485f-c1dd0d07cef4", "Demir", false, "emine.demir@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000011", 0, "Ahmet", "219eae74-38b9-c1ce-a076-88f9e593665e", "ahmet.demir@sesparator.test", true, true, null, "AHMET.DEMIR@SESPARATOR.TEST", "AHMET.DEMIR@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "0813e68f-78a4-de99-1a21-ab3a113e6bf6", "Demir", false, "ahmet.demir@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000012", 0, "Can", "a0f02e68-86f8-4dba-8029-61a2aa97ee49", "can.demir@sesparator.test", true, true, null, "CAN.DEMIR@SESPARATOR.TEST", "CAN.DEMIR@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "02546ff5-4084-196a-4707-195419571851", "Demir", false, "can.demir@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000013", 0, "Ayten", "c8df5b81-af6e-cf19-b977-14b9e5ca3ca8", "ayten.sahin@sesparator.test", true, true, null, "AYTEN.SAHIN@SESPARATOR.TEST", "AYTEN.SAHIN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "65445e4c-86ce-f9b0-7492-64e71e6eb407", "Şahin", false, "ayten.sahin@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000014", 0, "Hüseyin", "f67257ac-a913-bb56-d6f1-3459fe670004", "huseyin.sahin@sesparator.test", true, true, null, "HUSEYIN.SAHIN@SESPARATOR.TEST", "HUSEYIN.SAHIN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "b2e55b23-d383-64aa-1c96-68c65d9d4575", "Şahin", false, "huseyin.sahin@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000015", 0, "Merve", "509f91dc-b566-6395-efa0-11868aa46331", "merve.sahin@sesparator.test", true, true, null, "MERVE.SAHIN@SESPARATOR.TEST", "MERVE.SAHIN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "4b3fa5ad-9dce-9316-6e02-68fb9c790529", "Şahin", false, "merve.sahin@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000016", 0, "Selin", "8f8b2e5b-c908-379e-130a-7d54ad526e08", "selin.sahin@sesparator.test", true, true, null, "SELIN.SAHIN@SESPARATOR.TEST", "SELIN.SAHIN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "db9cfef9-1120-c0b9-2a62-a1be1af810db", "Şahin", false, "selin.sahin@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000017", 0, "Zehra", "649416c7-d812-99f4-b01f-3c791446af8b", "zehra.celik@sesparator.test", true, true, null, "ZEHRA.CELIK@SESPARATOR.TEST", "ZEHRA.CELIK@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "298f017a-0377-a09f-2ff4-0bb362305f65", "Çelik", false, "zehra.celik@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000018", 0, "İbrahim", "26c75878-e88b-7f45-f123-e1c2bddd841a", "ibrahim.celik@sesparator.test", true, true, null, "IBRAHIM.CELIK@SESPARATOR.TEST", "IBRAHIM.CELIK@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "59fc7922-8b99-6238-4c68-6b68b7a20df5", "Çelik", false, "ibrahim.celik@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000019", 0, "Oğuz", "76aa7567-6ea4-51e3-b9b2-ec925922d115", "oguz.celik@sesparator.test", true, true, null, "OGUZ.CELIK@SESPARATOR.TEST", "OGUZ.CELIK@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "582046f9-ac86-b18f-713a-b28e813a337d", "Çelik", false, "oguz.celik@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000020", 0, "Sevgi", "fcc0d49f-4f58-9c68-a8a9-4b351eced775", "sevgi.yildiz@sesparator.test", true, true, null, "SEVGI.YILDIZ@SESPARATOR.TEST", "SEVGI.YILDIZ@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "21684a6c-7b83-1f47-ee11-06ca0e8a63cf", "Yıldız", false, "sevgi.yildiz@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000021", 0, "Ali", "122fda79-1f00-9039-8775-88c9e608a64f", "ali.yildiz@sesparator.test", true, true, null, "ALI.YILDIZ@SESPARATOR.TEST", "ALI.YILDIZ@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "1a0fc033-63ca-8f9b-f9c8-7436b31de2cb", "Yıldız", false, "ali.yildiz@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000022", 0, "Deniz", "d1da5493-f0a9-2522-8594-013a3eebfc47", "deniz.yildiz@sesparator.test", true, true, null, "DENIZ.YILDIZ@SESPARATOR.TEST", "DENIZ.YILDIZ@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "0d010fd5-e4e5-1db7-1d54-41393913867e", "Yıldız", false, "deniz.yildiz@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000023", 0, "Kerem", "7de25087-32df-fa57-c1c7-c95cef19c336", "kerem.yildiz@sesparator.test", true, true, null, "KEREM.YILDIZ@SESPARATOR.TEST", "KEREM.YILDIZ@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "770d52ea-08e5-0e21-f989-0dc7e4e5ecdc", "Yıldız", false, "kerem.yildiz@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000024", 0, "Gülsüm", "c43e1eb6-e01f-d6c5-0703-df1bc479a0e8", "gulsum.yildirim@sesparator.test", true, true, null, "GULSUM.YILDIRIM@SESPARATOR.TEST", "GULSUM.YILDIRIM@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "b03a72f1-648d-b23d-f240-c195e9b8fa12", "Yıldırım", false, "gulsum.yildirim@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000025", 0, "Hasan", "218589a9-78ee-d9a0-3139-781451a5e4d9", "hasan.yildirim@sesparator.test", true, true, null, "HASAN.YILDIRIM@SESPARATOR.TEST", "HASAN.YILDIRIM@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "2a748327-4df7-06d6-5791-ba540f11ac63", "Yıldırım", false, "hasan.yildirim@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000026", 0, "Ece", "c2d5bdf9-b1b4-e0ad-af2b-586a01cb7df3", "ece.yildirim@sesparator.test", true, true, null, "ECE.YILDIRIM@SESPARATOR.TEST", "ECE.YILDIRIM@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "0f2d0e21-2ea0-5d38-67af-dffd4dafe29b", "Yıldırım", false, "ece.yildirim@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000027", 0, "Nermin", "ced57560-9b5b-ec32-211c-5950f0d7238b", "nermin.ozturk@sesparator.test", true, true, null, "NERMIN.OZTURK@SESPARATOR.TEST", "NERMIN.OZTURK@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "a8fa343e-0996-c660-e34f-bc83096f604d", "Öztürk", false, "nermin.ozturk@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000028", 0, "Osman", "0faf7a87-0bd5-312b-9c49-fce86659e085", "osman.ozturk@sesparator.test", true, true, null, "OSMAN.OZTURK@SESPARATOR.TEST", "OSMAN.OZTURK@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "58362de8-e627-5d31-c124-740c98a3020e", "Öztürk", false, "osman.ozturk@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000029", 0, "Berk", "48e9debc-68f7-ee43-4778-f0fd59bf853c", "berk.ozturk@sesparator.test", true, true, null, "BERK.OZTURK@SESPARATOR.TEST", "BERK.OZTURK@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "d917ff16-cf28-d776-7f1a-9ff965dc0105", "Öztürk", false, "berk.ozturk@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000030", 0, "İrem", "79dfaf91-c07e-6394-0822-e7d4ecf9bdbc", "irem.ozturk@sesparator.test", true, true, null, "IREM.OZTURK@SESPARATOR.TEST", "IREM.OZTURK@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "cae5c6d9-d6ba-af03-0b16-89d59baebb29", "Öztürk", false, "irem.ozturk@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000031", 0, "Leyla", "2eef97c2-12c3-cd59-fe33-1e3d2015f1c5", "leyla.aydin@sesparator.test", true, true, null, "LEYLA.AYDIN@SESPARATOR.TEST", "LEYLA.AYDIN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "1bb36eb3-47a7-f071-3071-4ef810183182", "Aydın", false, "leyla.aydin@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000032", 0, "Murat", "3328741c-1bcf-887f-793b-0a0bd2d41b4e", "murat.aydin@sesparator.test", true, true, null, "MURAT.AYDIN@SESPARATOR.TEST", "MURAT.AYDIN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "de6e4cc8-7757-854b-ba27-2acae6a015e5", "Aydın", false, "murat.aydin@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000033", 0, "Cem", "3f6c1b64-e5b2-dc0b-ff1f-550786fb9880", "cem.aydin@sesparator.test", true, true, null, "CEM.AYDIN@SESPARATOR.TEST", "CEM.AYDIN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "b49aca5a-6ded-c910-d006-772f2caccce5", "Aydın", false, "cem.aydin@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000034", 0, "Meltem", "0817ceb4-d542-f66d-edf8-ea17f6a0cdcf", "meltem.ozdemir@sesparator.test", true, true, null, "MELTEM.OZDEMIR@SESPARATOR.TEST", "MELTEM.OZDEMIR@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "9bd71404-9e9a-7941-bcbf-3ab2e874bfbe", "Özdemir", false, "meltem.ozdemir@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000035", 0, "Serkan", "29b3a2ad-1b82-6af2-6d3e-92c9b9504960", "serkan.ozdemir@sesparator.test", true, true, null, "SERKAN.OZDEMIR@SESPARATOR.TEST", "SERKAN.OZDEMIR@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "8f46d93f-4d4b-30f5-0f7f-84f2c62fa7e0", "Özdemir", false, "serkan.ozdemir@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000036", 0, "Defne", "2cba0d21-be77-2436-b090-99122f4ef516", "defne.ozdemir@sesparator.test", true, true, null, "DEFNE.OZDEMIR@SESPARATOR.TEST", "DEFNE.OZDEMIR@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "524b4e91-b2e3-244f-b6e2-039c8a24e7db", "Özdemir", false, "defne.ozdemir@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000037", 0, "Arda", "3d1852a2-67f5-eced-94ce-9942bb05b2d9", "arda.ozdemir@sesparator.test", true, true, null, "ARDA.OZDEMIR@SESPARATOR.TEST", "ARDA.OZDEMIR@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "a55d669a-71aa-d5ad-3d9f-e3f44fd21726", "Özdemir", false, "arda.ozdemir@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000038", 0, "Sibel", "6ad7dc11-3719-09ec-416c-ad475f976def", "sibel.arslan@sesparator.test", true, true, null, "SIBEL.ARSLAN@SESPARATOR.TEST", "SIBEL.ARSLAN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "14335611-b76c-f88c-7908-c83c9e327970", "Arslan", false, "sibel.arslan@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000039", 0, "Kemal", "4409ffd3-e298-d99b-6303-dbe2b7917af5", "kemal.arslan@sesparator.test", true, true, null, "KEMAL.ARSLAN@SESPARATOR.TEST", "KEMAL.ARSLAN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "7610aa8c-f243-5656-f909-51f940d96929", "Arslan", false, "kemal.arslan@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000040", 0, "Gizem", "74164012-689f-5b8e-45e9-2d273008d64e", "gizem.arslan@sesparator.test", true, true, null, "GIZEM.ARSLAN@SESPARATOR.TEST", "GIZEM.ARSLAN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "df9e639d-7c5b-8f2c-ac62-d87229a90e37", "Arslan", false, "gizem.arslan@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000041", 0, "Filiz", "054f7199-a35e-8a8c-1e9a-65d7fd8d97b7", "filiz.dogan@sesparator.test", true, true, null, "FILIZ.DOGAN@SESPARATOR.TEST", "FILIZ.DOGAN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "411c18e5-022c-c133-b8e9-a57c6a35d542", "Doğan", false, "filiz.dogan@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000042", 0, "Yusuf", "5c9c9223-2ac4-ed51-bdf2-b25e0396b523", "yusuf.dogan@sesparator.test", true, true, null, "YUSUF.DOGAN@SESPARATOR.TEST", "YUSUF.DOGAN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "d7a9ed50-0e25-f862-ea36-0fb0c8418c92", "Doğan", false, "yusuf.dogan@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000043", 0, "Ozan", "035c321a-54f4-ec81-9ed9-eeedb2dd1c46", "ozan.dogan@sesparator.test", true, true, null, "OZAN.DOGAN@SESPARATOR.TEST", "OZAN.DOGAN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "0ea761a3-41af-ace9-df2a-8e97ab269bbb", "Doğan", false, "ozan.dogan@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000044", 0, "Buse", "fc53d570-02fa-480d-b0ec-9eab756cefeb", "buse.dogan@sesparator.test", true, true, null, "BUSE.DOGAN@SESPARATOR.TEST", "BUSE.DOGAN@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "7a948ab6-2d43-2503-2c42-fa71104fdfbb", "Doğan", false, "buse.dogan@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000045", 0, "Esra", "578e57c9-c0af-0f53-e372-b2e8634d3f92", "esra.kilic@sesparator.test", true, true, null, "ESRA.KILIC@SESPARATOR.TEST", "ESRA.KILIC@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "744bdab0-38af-8a10-3d6d-1d785db47c4b", "Kılıç", false, "esra.kilic@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000046", 0, "Tolga", "27863c91-f026-8b2d-66f0-62494e8d1a27", "tolga.kilic@sesparator.test", true, true, null, "TOLGA.KILIC@SESPARATOR.TEST", "TOLGA.KILIC@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "16cd812e-e840-0b7a-5a3e-3292ddf0873c", "Kılıç", false, "tolga.kilic@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000047", 0, "Mert", "30864faf-ccbd-0b23-d51a-5eb5f9c309bc", "mert.kilic@sesparator.test", true, true, null, "MERT.KILIC@SESPARATOR.TEST", "MERT.KILIC@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "7f5f01f2-618f-c1ac-aa00-e073c53d5441", "Kılıç", false, "mert.kilic@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000048", 0, "Derya", "f60274aa-e6c7-23f7-b9f7-3f2814c9ef84", "derya.koc@sesparator.test", true, true, null, "DERYA.KOC@SESPARATOR.TEST", "DERYA.KOC@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "494719e2-54fd-007c-1de2-433d9a26dd54", "Koç", false, "derya.koc@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000049", 0, "Volkan", "5414068f-54ec-bef3-a969-3cd3901e58f7", "volkan.koc@sesparator.test", true, true, null, "VOLKAN.KOC@SESPARATOR.TEST", "VOLKAN.KOC@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "7b7926a6-d733-d84e-3ceb-ffa5c5fb2123", "Koç", false, "volkan.koc@sesparator.test" },
                    { "00000000-0000-0000-0001-000000000050", 0, "Ada", "7a9bcad2-1e48-0793-e8f6-bb51795142ac", "ada.koc@sesparator.test", true, true, null, "ADA.KOC@SESPARATOR.TEST", "ADA.KOC@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "ee85038d-ee6b-a0e8-fc16-f6e40c5233ba", "Koç", false, "ada.koc@sesparator.test" },
                    { "00000000-0000-0000-0002-000000000001", 0, "Sistem", "e5838571-7d5d-c1ac-7147-b2a27b18cd81", "yonetici@sesparator.test", true, true, null, "YONETICI@SESPARATOR.TEST", "YONETICI@SESPARATOR.TEST", "AQAAAAIAAYagAAAAEEwjsXDlQfaIG7Fj0Enri0J3MJuHnb0NRqLB1wbEpkCtHDIIiYjeApXyxyrGOQeyCg==", null, false, "7d649d8b-8a6d-5e86-ce62-136384f56c11", "Yöneticisi", false, "yonetici@sesparator.test" }
                });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "Id", "EsZamanlilikDamgasi", "Ad", "NormalizeAd" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0003-000000000001", "b1f6a3e2-0c4d-4f6e-9a51-3d2c7e8f0a11", "Musteri", "MUSTERI" },
                    { "00000000-0000-0000-0003-000000000002", "c2e7b4f3-1d5e-4a7f-8b62-4e3d8f9a1b22", "Yonetici", "YONETICI" }
                });

            migrationBuilder.InsertData(
                table: "Hesaplar",
                columns: new[] { "Id", "Bakiye", "HesapTuru", "Iban", "KullaniciId", "ParaBirimi" },
                values: new object[,]
                {
                    { 1, 33000m, 0, "TR820099902999000101813166", "00000000-0000-0000-0001-000000000001", "TRY" },
                    { 2, 86000m, 1, "TR690099906641000102485288", "00000000-0000-0000-0001-000000000001", "TRY" },
                    { 3, 49000m, 0, "TR520099901210000201851762", "00000000-0000-0000-0001-000000000002", "TRY" },
                    { 4, 10000m, 1, "TR550099904911000202682927", "00000000-0000-0000-0001-000000000002", "TRY" },
                    { 5, 71900m, 0, "TR260099907181000301488803", "00000000-0000-0000-0001-000000000003", "TRY" },
                    { 6, 63500m, 1, "TR660099904096000302516206", "00000000-0000-0000-0001-000000000003", "TRY" },
                    { 7, 118950m, 0, "TR350099907277000401724902", "00000000-0000-0000-0001-000000000004", "TRY" },
                    { 8, 15500m, 1, "TR130099902260000402319916", "00000000-0000-0000-0001-000000000004", "TRY" },
                    { 9, 17100m, 0, "TR960099906649000501732522", "00000000-0000-0000-0001-000000000005", "TRY" },
                    { 10, 116000m, 1, "TR510099903891000502232654", "00000000-0000-0000-0001-000000000005", "TRY" },
                    { 11, 6500m, 0, "TR270099905613000601131315", "00000000-0000-0000-0001-000000000006", "TRY" },
                    { 12, 5000m, 1, "TR970099904763000602971420", "00000000-0000-0000-0001-000000000006", "TRY" },
                    { 13, 96000m, 0, "TR060099908279000701912925", "00000000-0000-0000-0001-000000000007", "TRY" },
                    { 14, 108000m, 1, "TR260099908415000702778668", "00000000-0000-0000-0001-000000000007", "TRY" },
                    { 15, 61000m, 0, "TR490099906410000801889120", "00000000-0000-0000-0001-000000000008", "TRY" },
                    { 16, 40000m, 1, "TR420099901702000802452506", "00000000-0000-0000-0001-000000000008", "TRY" },
                    { 17, 53450m, 0, "TR410099901516000901895360", "00000000-0000-0000-0001-000000000009", "TRY" },
                    { 18, 32000m, 1, "TR050099907811000902290619", "00000000-0000-0000-0001-000000000009", "TRY" },
                    { 19, 34700m, 0, "TR080099906166001001498861", "00000000-0000-0000-0001-000000000010", "TRY" },
                    { 20, 122000m, 1, "TR590099907312001002209853", "00000000-0000-0000-0001-000000000010", "TRY" },
                    { 21, 121000m, 0, "TR860099902167001101204469", "00000000-0000-0000-0001-000000000011", "TRY" },
                    { 22, 85000m, 1, "TR670099908344001102658548", "00000000-0000-0000-0001-000000000011", "TRY" },
                    { 23, 81700m, 0, "TR730099903804001201973753", "00000000-0000-0000-0001-000000000012", "TRY" },
                    { 24, 58500m, 1, "TR880099901897001202262348", "00000000-0000-0000-0001-000000000012", "TRY" },
                    { 25, 58650m, 0, "TR040099906253001301499966", "00000000-0000-0000-0001-000000000013", "TRY" },
                    { 26, 53500m, 1, "TR690099905202001302841446", "00000000-0000-0000-0001-000000000013", "TRY" },
                    { 27, 77150m, 0, "TR700099903344001401851727", "00000000-0000-0000-0001-000000000014", "TRY" },
                    { 28, 27000m, 1, "TR790099904179001402185593", "00000000-0000-0000-0001-000000000014", "TRY" },
                    { 29, 60900m, 0, "TR460099907760001501818294", "00000000-0000-0000-0001-000000000015", "TRY" },
                    { 30, 97000m, 1, "TR930099904580001502152697", "00000000-0000-0000-0001-000000000015", "TRY" },
                    { 31, 112000m, 0, "TR070099907168001601334221", "00000000-0000-0000-0001-000000000016", "TRY" },
                    { 32, 113000m, 1, "TR320099904354001602413043", "00000000-0000-0000-0001-000000000016", "TRY" },
                    { 33, 115000m, 0, "TR200099908410001701297996", "00000000-0000-0000-0001-000000000017", "TRY" },
                    { 34, 137000m, 1, "TR040099901930001702710430", "00000000-0000-0000-0001-000000000017", "TRY" },
                    { 35, 90500m, 0, "TR450099908758001801548076", "00000000-0000-0000-0001-000000000018", "TRY" },
                    { 36, 110500m, 1, "TR210099908755001802718478", "00000000-0000-0000-0001-000000000018", "TRY" },
                    { 37, 91500m, 0, "TR040099907407001901901463", "00000000-0000-0000-0001-000000000019", "TRY" },
                    { 38, 7500m, 1, "TR140099906109001902201505", "00000000-0000-0000-0001-000000000019", "TRY" },
                    { 39, 20000m, 0, "TR030099905381002001477930", "00000000-0000-0000-0001-000000000020", "TRY" },
                    { 40, 48500m, 1, "TR420099905213002002950522", "00000000-0000-0000-0001-000000000020", "TRY" },
                    { 41, 119000m, 0, "TR320099908484002101485040", "00000000-0000-0000-0001-000000000021", "TRY" },
                    { 42, 77500m, 1, "TR280099909746002102380663", "00000000-0000-0000-0001-000000000021", "TRY" },
                    { 43, 148000m, 0, "TR190099905586002201354710", "00000000-0000-0000-0001-000000000022", "TRY" },
                    { 44, 148500m, 1, "TR500099903174002202389559", "00000000-0000-0000-0001-000000000022", "TRY" },
                    { 45, 139500m, 0, "TR590099907601002301906842", "00000000-0000-0000-0001-000000000023", "TRY" },
                    { 46, 19500m, 1, "TR360099906435002302298751", "00000000-0000-0000-0001-000000000023", "TRY" },
                    { 47, 36450m, 0, "TR760099901500002401808858", "00000000-0000-0000-0001-000000000024", "TRY" },
                    { 48, 30500m, 1, "TR390099906272002402820672", "00000000-0000-0000-0001-000000000024", "TRY" },
                    { 49, 101500m, 0, "TR630099904936002501953528", "00000000-0000-0000-0001-000000000025", "TRY" },
                    { 50, 36500m, 1, "TR080099906282002502815799", "00000000-0000-0000-0001-000000000025", "TRY" },
                    { 51, 30200m, 0, "TR560099903462002601815328", "00000000-0000-0000-0001-000000000026", "TRY" },
                    { 52, 99000m, 1, "TR660099904335002602200044", "00000000-0000-0000-0001-000000000026", "TRY" },
                    { 53, 26500m, 0, "TR370099905805002701547119", "00000000-0000-0000-0001-000000000027", "TRY" },
                    { 54, 17500m, 1, "TR260099905522002702381020", "00000000-0000-0000-0001-000000000027", "TRY" },
                    { 55, 16000m, 0, "TR050099908814002801193464", "00000000-0000-0000-0001-000000000028", "TRY" },
                    { 56, 17000m, 1, "TR040099902037002802288156", "00000000-0000-0000-0001-000000000028", "TRY" },
                    { 57, 30500m, 0, "TR550099903509002901109600", "00000000-0000-0000-0001-000000000029", "TRY" },
                    { 58, 147000m, 1, "TR510099907606002902544898", "00000000-0000-0000-0001-000000000029", "TRY" },
                    { 59, 45500m, 0, "TR640099908394003001262419", "00000000-0000-0000-0001-000000000030", "TRY" },
                    { 60, 143500m, 1, "TR910099905383003002496749", "00000000-0000-0000-0001-000000000030", "TRY" },
                    { 61, 125500m, 0, "TR320099907615003101650482", "00000000-0000-0000-0001-000000000031", "TRY" },
                    { 62, 33500m, 1, "TR830099909315003102848844", "00000000-0000-0000-0001-000000000031", "TRY" },
                    { 63, 95200m, 0, "TR220099902671003201218684", "00000000-0000-0000-0001-000000000032", "TRY" },
                    { 64, 142500m, 1, "TR390099904635003202116756", "00000000-0000-0000-0001-000000000032", "TRY" },
                    { 65, 101000m, 0, "TR590099906887003301346346", "00000000-0000-0000-0001-000000000033", "TRY" },
                    { 66, 53500m, 1, "TR770099903050003302592844", "00000000-0000-0000-0001-000000000033", "TRY" },
                    { 67, 72000m, 0, "TR800099905368003401761725", "00000000-0000-0000-0001-000000000034", "TRY" },
                    { 68, 39500m, 1, "TR310099903189003402997436", "00000000-0000-0000-0001-000000000034", "TRY" },
                    { 69, 61850m, 0, "TR940099902662003501558065", "00000000-0000-0000-0001-000000000035", "TRY" },
                    { 70, 112500m, 1, "TR240099908696003502777033", "00000000-0000-0000-0001-000000000035", "TRY" },
                    { 71, 38950m, 0, "TR210099907372003601256092", "00000000-0000-0000-0001-000000000036", "TRY" },
                    { 72, 109000m, 1, "TR180099901080003602718838", "00000000-0000-0000-0001-000000000036", "TRY" },
                    { 73, 84950m, 0, "TR660099902286003701626095", "00000000-0000-0000-0001-000000000037", "TRY" },
                    { 74, 115500m, 1, "TR690099901238003702922466", "00000000-0000-0000-0001-000000000037", "TRY" },
                    { 75, 63450m, 0, "TR030099907874003801519438", "00000000-0000-0000-0001-000000000038", "TRY" },
                    { 76, 106000m, 1, "TR460099906810003802432351", "00000000-0000-0000-0001-000000000038", "TRY" },
                    { 77, 130000m, 0, "TR940099902179003901851260", "00000000-0000-0000-0001-000000000039", "TRY" },
                    { 78, 103500m, 1, "TR670099906776003902953900", "00000000-0000-0000-0001-000000000039", "TRY" },
                    { 79, 65000m, 0, "TR130099908587004001414867", "00000000-0000-0000-0001-000000000040", "TRY" },
                    { 80, 99500m, 1, "TR740099904251004002668857", "00000000-0000-0000-0001-000000000040", "TRY" },
                    { 81, 5500m, 0, "TR080099909332004101851568", "00000000-0000-0000-0001-000000000041", "TRY" },
                    { 82, 54500m, 1, "TR820099903477004102998041", "00000000-0000-0000-0001-000000000041", "TRY" },
                    { 83, 30650m, 0, "TR860099909743004201282065", "00000000-0000-0000-0001-000000000042", "TRY" },
                    { 84, 96500m, 1, "TR790099909644004202852236", "00000000-0000-0000-0001-000000000042", "TRY" },
                    { 85, 42500m, 0, "TR280099907035004301307654", "00000000-0000-0000-0001-000000000043", "TRY" },
                    { 86, 64500m, 1, "TR400099902344004302765546", "00000000-0000-0000-0001-000000000043", "TRY" },
                    { 87, 13000m, 0, "TR050099905614004401435200", "00000000-0000-0000-0001-000000000044", "TRY" },
                    { 88, 105500m, 1, "TR620099909823004402638760", "00000000-0000-0000-0001-000000000044", "TRY" },
                    { 89, 110900m, 0, "TR710099903646004501221252", "00000000-0000-0000-0001-000000000045", "TRY" },
                    { 90, 21500m, 1, "TR960099907209004502483781", "00000000-0000-0000-0001-000000000045", "TRY" },
                    { 91, 130000m, 0, "TR920099907549004601396183", "00000000-0000-0000-0001-000000000046", "TRY" },
                    { 92, 58500m, 1, "TR510099901445004602403528", "00000000-0000-0000-0001-000000000046", "TRY" },
                    { 93, 115250m, 0, "TR930099904179004701278046", "00000000-0000-0000-0001-000000000047", "TRY" },
                    { 94, 50500m, 1, "TR760099901761004702541912", "00000000-0000-0000-0001-000000000047", "TRY" },
                    { 95, 1400m, 0, "TR790099905261004801886142", "00000000-0000-0000-0001-000000000048", "TRY" },
                    { 96, 19000m, 1, "TR810099904918004802995670", "00000000-0000-0000-0001-000000000048", "TRY" },
                    { 97, 43850m, 0, "TR180099906097004901966997", "00000000-0000-0000-0001-000000000049", "TRY" },
                    { 98, 149500m, 1, "TR920099907885004902434306", "00000000-0000-0000-0001-000000000049", "TRY" },
                    { 99, 93300m, 0, "TR590099907439005001556086", "00000000-0000-0000-0001-000000000050", "TRY" },
                    { 100, 59000m, 1, "TR110099904834005002770205", "00000000-0000-0000-0001-000000000050", "TRY" }
                });

            migrationBuilder.InsertData(
                table: "Kartlar",
                columns: new[] { "Id", "Borc", "KullaniciId", "Limit", "MaskeliKartNo", "SonOdemeTarihi" },
                values: new object[,]
                {
                    { 1, 4100m, "00000000-0000-0000-0001-000000000001", 35000m, "5412 **** **** 0436", new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 15300m, "00000000-0000-0000-0001-000000000002", 40000m, "5412 **** **** 3901", new DateTime(2026, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2850m, "00000000-0000-0000-0001-000000000003", 30000m, "5412 **** **** 5873", new DateTime(2026, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 30900m, "00000000-0000-0000-0001-000000000004", 70000m, "5412 **** **** 5411", new DateTime(2026, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3900m, "00000000-0000-0000-0001-000000000005", 10000m, "5412 **** **** 0459", new DateTime(2026, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 650m, "00000000-0000-0000-0001-000000000006", 15000m, "5412 **** **** 1153", new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 5350m, "00000000-0000-0000-0001-000000000007", 75000m, "5412 **** **** 3640", new DateTime(2026, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 33550m, "00000000-0000-0000-0001-000000000008", 70000m, "5412 **** **** 6537", new DateTime(2026, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9400m, "00000000-0000-0000-0001-000000000009", 65000m, "5412 **** **** 9457", new DateTime(2026, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 5100m, "00000000-0000-0000-0001-000000000010", 15000m, "5412 **** **** 7608", new DateTime(2026, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 16350m, "00000000-0000-0000-0001-000000000011", 70000m, "5412 **** **** 7837", new DateTime(2026, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 22750m, "00000000-0000-0000-0001-000000000012", 75000m, "5412 **** **** 7847", new DateTime(2026, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 16650m, "00000000-0000-0000-0001-000000000013", 35000m, "5412 **** **** 5323", new DateTime(2026, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 2000m, "00000000-0000-0000-0001-000000000014", 70000m, "5412 **** **** 7064", new DateTime(2026, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 7950m, "00000000-0000-0000-0001-000000000015", 15000m, "5412 **** **** 4283", new DateTime(2026, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 21400m, "00000000-0000-0000-0001-000000000016", 70000m, "5412 **** **** 1526", new DateTime(2026, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 13300m, "00000000-0000-0000-0001-000000000017", 50000m, "5412 **** **** 2593", new DateTime(2026, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 5450m, "00000000-0000-0000-0001-000000000018", 15000m, "5412 **** **** 5379", new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 24750m, "00000000-0000-0000-0001-000000000019", 45000m, "5412 **** **** 2771", new DateTime(2026, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 1450m, "00000000-0000-0000-0001-000000000020", 30000m, "5412 **** **** 5210", new DateTime(2026, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 4150m, "00000000-0000-0000-0001-000000000021", 15000m, "5412 **** **** 4365", new DateTime(2026, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 15350m, "00000000-0000-0000-0001-000000000022", 30000m, "5412 **** **** 8348", new DateTime(2026, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 9800m, "00000000-0000-0000-0001-000000000023", 55000m, "5412 **** **** 8909", new DateTime(2026, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 550m, "00000000-0000-0000-0001-000000000024", 65000m, "5412 **** **** 4857", new DateTime(2026, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 4200m, "00000000-0000-0000-0001-000000000025", 70000m, "5412 **** **** 6843", new DateTime(2026, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 2900m, "00000000-0000-0000-0001-000000000026", 55000m, "5412 **** **** 5245", new DateTime(2026, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 21400m, "00000000-0000-0000-0001-000000000027", 65000m, "5412 **** **** 5571", new DateTime(2026, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 3350m, "00000000-0000-0000-0001-000000000028", 10000m, "5412 **** **** 0455", new DateTime(2026, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 100m, "00000000-0000-0000-0001-000000000029", 20000m, "5412 **** **** 9573", new DateTime(2026, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 39050m, "00000000-0000-0000-0001-000000000030", 75000m, "5412 **** **** 2055", new DateTime(2026, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 650m, "00000000-0000-0000-0001-000000000031", 25000m, "5412 **** **** 3240", new DateTime(2026, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 3350m, "00000000-0000-0000-0001-000000000032", 45000m, "5412 **** **** 5405", new DateTime(2026, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 2450m, "00000000-0000-0000-0001-000000000033", 65000m, "5412 **** **** 0014", new DateTime(2026, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 5400m, "00000000-0000-0000-0001-000000000034", 25000m, "5412 **** **** 0737", new DateTime(2026, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 10500m, "00000000-0000-0000-0001-000000000035", 30000m, "5412 **** **** 4235", new DateTime(2026, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 17500m, "00000000-0000-0000-0001-000000000036", 70000m, "5412 **** **** 0498", new DateTime(2026, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 150m, "00000000-0000-0000-0001-000000000037", 50000m, "5412 **** **** 7816", new DateTime(2026, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 10400m, "00000000-0000-0000-0001-000000000038", 20000m, "5412 **** **** 8378", new DateTime(2026, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 13900m, "00000000-0000-0000-0001-000000000039", 45000m, "5412 **** **** 3571", new DateTime(2026, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 22500m, "00000000-0000-0000-0001-000000000040", 75000m, "5412 **** **** 3198", new DateTime(2026, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 17600m, "00000000-0000-0000-0001-000000000041", 50000m, "5412 **** **** 6364", new DateTime(2026, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 27350m, "00000000-0000-0000-0001-000000000042", 50000m, "5412 **** **** 4791", new DateTime(2026, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 3100m, "00000000-0000-0000-0001-000000000043", 15000m, "5412 **** **** 2208", new DateTime(2026, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 11200m, "00000000-0000-0000-0001-000000000044", 20000m, "5412 **** **** 7507", new DateTime(2026, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 26500m, "00000000-0000-0000-0001-000000000045", 55000m, "5412 **** **** 1777", new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 450m, "00000000-0000-0000-0001-000000000046", 35000m, "5412 **** **** 7265", new DateTime(2026, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 25000m, "00000000-0000-0000-0001-000000000047", 50000m, "5412 **** **** 8083", new DateTime(2026, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 22450m, "00000000-0000-0000-0001-000000000048", 50000m, "5412 **** **** 7265", new DateTime(2026, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 9550m, "00000000-0000-0000-0001-000000000049", 30000m, "5412 **** **** 5024", new DateTime(2026, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 4550m, "00000000-0000-0000-0001-000000000050", 15000m, "5412 **** **** 6903", new DateTime(2026, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "KayitliAlicilar",
                columns: new[] { "Id", "AdSoyad", "Iban", "KullaniciId", "TakmaAd" },
                values: new object[,]
                {
                    { 1, "Mustafa Yılmaz", "TR520099901210000201851762", "00000000-0000-0000-0001-000000000001", "Eşim" },
                    { 2, "Ayşe Yılmaz", "TR260099907181000301488803", "00000000-0000-0000-0001-000000000001", "Kızım" },
                    { 3, "Emre Yılmaz", "TR350099907277000401724902", "00000000-0000-0000-0001-000000000001", "Oğlum" },
                    { 4, "Hatice Kaya", "TR960099906649000501732522", "00000000-0000-0000-0001-000000000001", "Hatice" },
                    { 5, "Fatma Yılmaz", "TR820099902999000101813166", "00000000-0000-0000-0001-000000000002", "Eşim" },
                    { 6, "Ayşe Yılmaz", "TR260099907181000301488803", "00000000-0000-0000-0001-000000000002", "Kızım" },
                    { 7, "Emre Yılmaz", "TR350099907277000401724902", "00000000-0000-0000-0001-000000000002", "Oğlum" },
                    { 8, "Ahmet Demir", "TR860099902167001101204469", "00000000-0000-0000-0001-000000000002", "Ahmet" },
                    { 9, "Fatma Yılmaz", "TR820099902999000101813166", "00000000-0000-0000-0001-000000000003", "Annem" },
                    { 10, "Mustafa Yılmaz", "TR520099901210000201851762", "00000000-0000-0000-0001-000000000003", "Babam" },
                    { 11, "Emre Yılmaz", "TR350099907277000401724902", "00000000-0000-0000-0001-000000000003", "Kardeşim" },
                    { 12, "Zeynep Kaya", "TR060099908279000701912925", "00000000-0000-0000-0001-000000000003", "Zeynep" },
                    { 13, "Fatma Yılmaz", "TR820099902999000101813166", "00000000-0000-0000-0001-000000000004", "Annem" },
                    { 14, "Mustafa Yılmaz", "TR520099901210000201851762", "00000000-0000-0000-0001-000000000004", "Babam" },
                    { 15, "Ayşe Yılmaz", "TR260099907181000301488803", "00000000-0000-0000-0001-000000000004", "Ablam" },
                    { 16, "Mehmet Kaya", "TR270099905613000601131315", "00000000-0000-0000-0001-000000000005", "Eşim" },
                    { 17, "Zeynep Kaya", "TR060099908279000701912925", "00000000-0000-0000-0001-000000000005", "Kızım Zeynep" },
                    { 18, "Burak Kaya", "TR490099906410000801889120", "00000000-0000-0000-0001-000000000005", "Oğlum" },
                    { 19, "Elif Kaya", "TR410099901516000901895360", "00000000-0000-0000-0001-000000000005", "Kızım Elif" },
                    { 20, "Hatice Kaya", "TR960099906649000501732522", "00000000-0000-0000-0001-000000000006", "Eşim" },
                    { 21, "Zeynep Kaya", "TR060099908279000701912925", "00000000-0000-0000-0001-000000000006", "Kızım Zeynep" },
                    { 22, "Burak Kaya", "TR490099906410000801889120", "00000000-0000-0000-0001-000000000006", "Oğlum" },
                    { 23, "Elif Kaya", "TR410099901516000901895360", "00000000-0000-0000-0001-000000000006", "Kızım Elif" },
                    { 24, "Hatice Kaya", "TR960099906649000501732522", "00000000-0000-0000-0001-000000000007", "Annem" },
                    { 25, "Mehmet Kaya", "TR270099905613000601131315", "00000000-0000-0000-0001-000000000007", "Babam" },
                    { 26, "Burak Kaya", "TR490099906410000801889120", "00000000-0000-0000-0001-000000000007", "Kardeşim Burak" },
                    { 27, "Elif Kaya", "TR410099901516000901895360", "00000000-0000-0000-0001-000000000007", "Kardeşim Elif" },
                    { 28, "Hatice Kaya", "TR960099906649000501732522", "00000000-0000-0000-0001-000000000008", "Annem" },
                    { 29, "Mehmet Kaya", "TR270099905613000601131315", "00000000-0000-0000-0001-000000000008", "Babam" },
                    { 30, "Zeynep Kaya", "TR060099908279000701912925", "00000000-0000-0000-0001-000000000008", "Ablam" },
                    { 31, "Elif Kaya", "TR410099901516000901895360", "00000000-0000-0000-0001-000000000008", "Kardeşim" },
                    { 32, "Hatice Kaya", "TR960099906649000501732522", "00000000-0000-0000-0001-000000000009", "Annem" },
                    { 33, "Mehmet Kaya", "TR270099905613000601131315", "00000000-0000-0000-0001-000000000009", "Babam" },
                    { 34, "Zeynep Kaya", "TR060099908279000701912925", "00000000-0000-0000-0001-000000000009", "Ablam" },
                    { 35, "Burak Kaya", "TR490099906410000801889120", "00000000-0000-0000-0001-000000000009", "Abim" },
                    { 36, "Ahmet Demir", "TR860099902167001101204469", "00000000-0000-0000-0001-000000000010", "Eşim" },
                    { 37, "Can Demir", "TR730099903804001201973753", "00000000-0000-0000-0001-000000000010", "Oğlum" },
                    { 38, "Ayten Şahin", "TR040099906253001301499966", "00000000-0000-0000-0001-000000000010", "Ayten" },
                    { 39, "Hatice Kaya", "TR960099906649000501732522", "00000000-0000-0000-0001-000000000010", "Hatice" },
                    { 40, "Emine Demir", "TR080099906166001001498861", "00000000-0000-0000-0001-000000000011", "Eşim" },
                    { 41, "Can Demir", "TR730099903804001201973753", "00000000-0000-0000-0001-000000000011", "Oğlum" },
                    { 42, "İbrahim Çelik", "TR450099908758001801548076", "00000000-0000-0000-0001-000000000011", "İbrahim" },
                    { 43, "Mustafa Yılmaz", "TR520099901210000201851762", "00000000-0000-0000-0001-000000000011", "Mustafa" },
                    { 44, "Emine Demir", "TR080099906166001001498861", "00000000-0000-0000-0001-000000000012", "Annem" },
                    { 45, "Ahmet Demir", "TR860099902167001101204469", "00000000-0000-0000-0001-000000000012", "Babam" },
                    { 46, "Merve Şahin", "TR460099907760001501818294", "00000000-0000-0000-0001-000000000012", "Merve" },
                    { 47, "Zeynep Kaya", "TR060099908279000701912925", "00000000-0000-0000-0001-000000000012", "Zeynep" },
                    { 48, "Hüseyin Şahin", "TR700099903344001401851727", "00000000-0000-0000-0001-000000000013", "Eşim" },
                    { 49, "Merve Şahin", "TR460099907760001501818294", "00000000-0000-0000-0001-000000000013", "Kızım Merve" },
                    { 50, "Selin Şahin", "TR070099907168001601334221", "00000000-0000-0000-0001-000000000013", "Kızım Selin" },
                    { 51, "Zehra Çelik", "TR200099908410001701297996", "00000000-0000-0000-0001-000000000013", "Zehra" },
                    { 52, "Ayten Şahin", "TR040099906253001301499966", "00000000-0000-0000-0001-000000000014", "Eşim" },
                    { 53, "Merve Şahin", "TR460099907760001501818294", "00000000-0000-0000-0001-000000000014", "Kızım Merve" },
                    { 54, "Selin Şahin", "TR070099907168001601334221", "00000000-0000-0000-0001-000000000014", "Kızım Selin" },
                    { 55, "Ali Yıldız", "TR320099908484002101485040", "00000000-0000-0000-0001-000000000014", "Ali" },
                    { 56, "Ayten Şahin", "TR040099906253001301499966", "00000000-0000-0000-0001-000000000015", "Annem" },
                    { 57, "Hüseyin Şahin", "TR700099903344001401851727", "00000000-0000-0000-0001-000000000015", "Babam" },
                    { 58, "Selin Şahin", "TR070099907168001601334221", "00000000-0000-0000-0001-000000000015", "Kardeşim" },
                    { 59, "Oğuz Çelik", "TR040099907407001901901463", "00000000-0000-0000-0001-000000000015", "Oğuz" },
                    { 60, "Ayten Şahin", "TR040099906253001301499966", "00000000-0000-0000-0001-000000000016", "Annem" },
                    { 61, "Hüseyin Şahin", "TR700099903344001401851727", "00000000-0000-0000-0001-000000000016", "Babam" },
                    { 62, "Merve Şahin", "TR460099907760001501818294", "00000000-0000-0000-0001-000000000016", "Ablam" },
                    { 63, "İbrahim Çelik", "TR450099908758001801548076", "00000000-0000-0000-0001-000000000017", "Eşim" },
                    { 64, "Oğuz Çelik", "TR040099907407001901901463", "00000000-0000-0000-0001-000000000017", "Oğlum" },
                    { 65, "Sevgi Yıldız", "TR030099905381002001477930", "00000000-0000-0000-0001-000000000017", "Sevgi" },
                    { 66, "Ayten Şahin", "TR040099906253001301499966", "00000000-0000-0000-0001-000000000017", "Ayten" },
                    { 67, "Zehra Çelik", "TR200099908410001701297996", "00000000-0000-0000-0001-000000000018", "Eşim" },
                    { 68, "Oğuz Çelik", "TR040099907407001901901463", "00000000-0000-0000-0001-000000000018", "Oğlum" },
                    { 69, "Hasan Yıldırım", "TR630099904936002501953528", "00000000-0000-0000-0001-000000000018", "Hasan" },
                    { 70, "Ahmet Demir", "TR860099902167001101204469", "00000000-0000-0000-0001-000000000018", "Ahmet" },
                    { 71, "Zehra Çelik", "TR200099908410001701297996", "00000000-0000-0000-0001-000000000019", "Annem" },
                    { 72, "İbrahim Çelik", "TR450099908758001801548076", "00000000-0000-0000-0001-000000000019", "Babam" },
                    { 73, "Deniz Yıldız", "TR190099905586002201354710", "00000000-0000-0000-0001-000000000019", "Deniz" },
                    { 74, "Merve Şahin", "TR460099907760001501818294", "00000000-0000-0000-0001-000000000019", "Merve" },
                    { 75, "Ali Yıldız", "TR320099908484002101485040", "00000000-0000-0000-0001-000000000020", "Eşim" },
                    { 76, "Deniz Yıldız", "TR190099905586002201354710", "00000000-0000-0000-0001-000000000020", "Kızım" },
                    { 77, "Kerem Yıldız", "TR590099907601002301906842", "00000000-0000-0000-0001-000000000020", "Oğlum" },
                    { 78, "Gülsüm Yıldırım", "TR760099901500002401808858", "00000000-0000-0000-0001-000000000020", "Gülsüm" },
                    { 79, "Sevgi Yıldız", "TR030099905381002001477930", "00000000-0000-0000-0001-000000000021", "Eşim" },
                    { 80, "Deniz Yıldız", "TR190099905586002201354710", "00000000-0000-0000-0001-000000000021", "Kızım" },
                    { 81, "Kerem Yıldız", "TR590099907601002301906842", "00000000-0000-0000-0001-000000000021", "Oğlum" },
                    { 82, "Osman Öztürk", "TR050099908814002801193464", "00000000-0000-0000-0001-000000000021", "Osman" },
                    { 83, "Sevgi Yıldız", "TR030099905381002001477930", "00000000-0000-0000-0001-000000000022", "Annem" },
                    { 84, "Ali Yıldız", "TR320099908484002101485040", "00000000-0000-0000-0001-000000000022", "Babam" },
                    { 85, "Kerem Yıldız", "TR590099907601002301906842", "00000000-0000-0000-0001-000000000022", "Kardeşim" },
                    { 86, "Ece Yıldırım", "TR560099903462002601815328", "00000000-0000-0000-0001-000000000022", "Ece" },
                    { 87, "Sevgi Yıldız", "TR030099905381002001477930", "00000000-0000-0000-0001-000000000023", "Annem" },
                    { 88, "Ali Yıldız", "TR320099908484002101485040", "00000000-0000-0000-0001-000000000023", "Babam" },
                    { 89, "Deniz Yıldız", "TR190099905586002201354710", "00000000-0000-0000-0001-000000000023", "Ablam" },
                    { 90, "Hasan Yıldırım", "TR630099904936002501953528", "00000000-0000-0000-0001-000000000024", "Eşim" },
                    { 91, "Ece Yıldırım", "TR560099903462002601815328", "00000000-0000-0000-0001-000000000024", "Kızım" },
                    { 92, "Nermin Öztürk", "TR370099905805002701547119", "00000000-0000-0000-0001-000000000024", "Nermin" },
                    { 93, "Sevgi Yıldız", "TR030099905381002001477930", "00000000-0000-0000-0001-000000000024", "Sevgi" },
                    { 94, "Gülsüm Yıldırım", "TR760099901500002401808858", "00000000-0000-0000-0001-000000000025", "Eşim" },
                    { 95, "Ece Yıldırım", "TR560099903462002601815328", "00000000-0000-0000-0001-000000000025", "Kızım" },
                    { 96, "Murat Aydın", "TR220099902671003201218684", "00000000-0000-0000-0001-000000000025", "Murat" },
                    { 97, "İbrahim Çelik", "TR450099908758001801548076", "00000000-0000-0000-0001-000000000025", "İbrahim" },
                    { 98, "Gülsüm Yıldırım", "TR760099901500002401808858", "00000000-0000-0000-0001-000000000026", "Annem" },
                    { 99, "Hasan Yıldırım", "TR630099904936002501953528", "00000000-0000-0000-0001-000000000026", "Babam" },
                    { 100, "Berk Öztürk", "TR550099903509002901109600", "00000000-0000-0000-0001-000000000026", "Berk" },
                    { 101, "Deniz Yıldız", "TR190099905586002201354710", "00000000-0000-0000-0001-000000000026", "Deniz" },
                    { 102, "Osman Öztürk", "TR050099908814002801193464", "00000000-0000-0000-0001-000000000027", "Eşim" },
                    { 103, "Berk Öztürk", "TR550099903509002901109600", "00000000-0000-0000-0001-000000000027", "Oğlum" },
                    { 104, "İrem Öztürk", "TR640099908394003001262419", "00000000-0000-0000-0001-000000000027", "Kızım" },
                    { 105, "Leyla Aydın", "TR320099907615003101650482", "00000000-0000-0000-0001-000000000027", "Leyla" },
                    { 106, "Nermin Öztürk", "TR370099905805002701547119", "00000000-0000-0000-0001-000000000028", "Eşim" },
                    { 107, "Berk Öztürk", "TR550099903509002901109600", "00000000-0000-0000-0001-000000000028", "Oğlum" },
                    { 108, "İrem Öztürk", "TR640099908394003001262419", "00000000-0000-0000-0001-000000000028", "Kızım" },
                    { 109, "Serkan Özdemir", "TR940099902662003501558065", "00000000-0000-0000-0001-000000000028", "Serkan" },
                    { 110, "Nermin Öztürk", "TR370099905805002701547119", "00000000-0000-0000-0001-000000000029", "Annem" },
                    { 111, "Osman Öztürk", "TR050099908814002801193464", "00000000-0000-0000-0001-000000000029", "Babam" },
                    { 112, "İrem Öztürk", "TR640099908394003001262419", "00000000-0000-0000-0001-000000000029", "Kardeşim" },
                    { 113, "Cem Aydın", "TR590099906887003301346346", "00000000-0000-0000-0001-000000000029", "Cem" },
                    { 114, "Nermin Öztürk", "TR370099905805002701547119", "00000000-0000-0000-0001-000000000030", "Annem" },
                    { 115, "Osman Öztürk", "TR050099908814002801193464", "00000000-0000-0000-0001-000000000030", "Babam" },
                    { 116, "Berk Öztürk", "TR550099903509002901109600", "00000000-0000-0000-0001-000000000030", "Abim" },
                    { 117, "Murat Aydın", "TR220099902671003201218684", "00000000-0000-0000-0001-000000000031", "Eşim" },
                    { 118, "Cem Aydın", "TR590099906887003301346346", "00000000-0000-0000-0001-000000000031", "Oğlum" },
                    { 119, "Meltem Özdemir", "TR800099905368003401761725", "00000000-0000-0000-0001-000000000031", "Meltem" },
                    { 120, "Nermin Öztürk", "TR370099905805002701547119", "00000000-0000-0000-0001-000000000031", "Nermin" },
                    { 121, "Leyla Aydın", "TR320099907615003101650482", "00000000-0000-0000-0001-000000000032", "Eşim" },
                    { 122, "Cem Aydın", "TR590099906887003301346346", "00000000-0000-0000-0001-000000000032", "Oğlum" },
                    { 123, "Kemal Arslan", "TR940099902179003901851260", "00000000-0000-0000-0001-000000000032", "Kemal" },
                    { 124, "Hasan Yıldırım", "TR630099904936002501953528", "00000000-0000-0000-0001-000000000032", "Hasan" },
                    { 125, "Leyla Aydın", "TR320099907615003101650482", "00000000-0000-0000-0001-000000000033", "Annem" },
                    { 126, "Murat Aydın", "TR220099902671003201218684", "00000000-0000-0000-0001-000000000033", "Babam" },
                    { 127, "Defne Özdemir", "TR210099907372003601256092", "00000000-0000-0000-0001-000000000033", "Defne" },
                    { 128, "Berk Öztürk", "TR550099903509002901109600", "00000000-0000-0000-0001-000000000033", "Berk" },
                    { 129, "Serkan Özdemir", "TR940099902662003501558065", "00000000-0000-0000-0001-000000000034", "Eşim" },
                    { 130, "Defne Özdemir", "TR210099907372003601256092", "00000000-0000-0000-0001-000000000034", "Kızım" },
                    { 131, "Arda Özdemir", "TR660099902286003701626095", "00000000-0000-0000-0001-000000000034", "Oğlum" },
                    { 132, "Sibel Arslan", "TR030099907874003801519438", "00000000-0000-0000-0001-000000000034", "Sibel" },
                    { 133, "Meltem Özdemir", "TR800099905368003401761725", "00000000-0000-0000-0001-000000000035", "Eşim" },
                    { 134, "Defne Özdemir", "TR210099907372003601256092", "00000000-0000-0000-0001-000000000035", "Kızım" },
                    { 135, "Arda Özdemir", "TR660099902286003701626095", "00000000-0000-0000-0001-000000000035", "Oğlum" },
                    { 136, "Yusuf Doğan", "TR860099909743004201282065", "00000000-0000-0000-0001-000000000035", "Yusuf" },
                    { 137, "Meltem Özdemir", "TR800099905368003401761725", "00000000-0000-0000-0001-000000000036", "Annem" },
                    { 138, "Serkan Özdemir", "TR940099902662003501558065", "00000000-0000-0000-0001-000000000036", "Babam" },
                    { 139, "Arda Özdemir", "TR660099902286003701626095", "00000000-0000-0000-0001-000000000036", "Kardeşim" },
                    { 140, "Gizem Arslan", "TR130099908587004001414867", "00000000-0000-0000-0001-000000000036", "Gizem" },
                    { 141, "Meltem Özdemir", "TR800099905368003401761725", "00000000-0000-0000-0001-000000000037", "Annem" },
                    { 142, "Serkan Özdemir", "TR940099902662003501558065", "00000000-0000-0000-0001-000000000037", "Babam" },
                    { 143, "Defne Özdemir", "TR210099907372003601256092", "00000000-0000-0000-0001-000000000037", "Ablam" },
                    { 144, "Kemal Arslan", "TR940099902179003901851260", "00000000-0000-0000-0001-000000000038", "Eşim" },
                    { 145, "Gizem Arslan", "TR130099908587004001414867", "00000000-0000-0000-0001-000000000038", "Kızım" },
                    { 146, "Filiz Doğan", "TR080099909332004101851568", "00000000-0000-0000-0001-000000000038", "Filiz" },
                    { 147, "Meltem Özdemir", "TR800099905368003401761725", "00000000-0000-0000-0001-000000000038", "Meltem" },
                    { 148, "Sibel Arslan", "TR030099907874003801519438", "00000000-0000-0000-0001-000000000039", "Eşim" },
                    { 149, "Gizem Arslan", "TR130099908587004001414867", "00000000-0000-0000-0001-000000000039", "Kızım" },
                    { 150, "Tolga Kılıç", "TR920099907549004601396183", "00000000-0000-0000-0001-000000000039", "Tolga" },
                    { 151, "Murat Aydın", "TR220099902671003201218684", "00000000-0000-0000-0001-000000000039", "Murat" },
                    { 152, "Sibel Arslan", "TR030099907874003801519438", "00000000-0000-0000-0001-000000000040", "Annem" },
                    { 153, "Kemal Arslan", "TR940099902179003901851260", "00000000-0000-0000-0001-000000000040", "Babam" },
                    { 154, "Ozan Doğan", "TR280099907035004301307654", "00000000-0000-0000-0001-000000000040", "Ozan" },
                    { 155, "Defne Özdemir", "TR210099907372003601256092", "00000000-0000-0000-0001-000000000040", "Defne" },
                    { 156, "Yusuf Doğan", "TR860099909743004201282065", "00000000-0000-0000-0001-000000000041", "Eşim" },
                    { 157, "Ozan Doğan", "TR280099907035004301307654", "00000000-0000-0000-0001-000000000041", "Oğlum" },
                    { 158, "Buse Doğan", "TR050099905614004401435200", "00000000-0000-0000-0001-000000000041", "Kızım" },
                    { 159, "Esra Kılıç", "TR710099903646004501221252", "00000000-0000-0000-0001-000000000041", "Esra" },
                    { 160, "Filiz Doğan", "TR080099909332004101851568", "00000000-0000-0000-0001-000000000042", "Eşim" },
                    { 161, "Ozan Doğan", "TR280099907035004301307654", "00000000-0000-0000-0001-000000000042", "Oğlum" },
                    { 162, "Buse Doğan", "TR050099905614004401435200", "00000000-0000-0000-0001-000000000042", "Kızım" },
                    { 163, "Volkan Koç", "TR180099906097004901966997", "00000000-0000-0000-0001-000000000042", "Volkan" },
                    { 164, "Filiz Doğan", "TR080099909332004101851568", "00000000-0000-0000-0001-000000000043", "Annem" },
                    { 165, "Yusuf Doğan", "TR860099909743004201282065", "00000000-0000-0000-0001-000000000043", "Babam" },
                    { 166, "Buse Doğan", "TR050099905614004401435200", "00000000-0000-0000-0001-000000000043", "Kardeşim" },
                    { 167, "Mert Kılıç", "TR930099904179004701278046", "00000000-0000-0000-0001-000000000043", "Mert" },
                    { 168, "Filiz Doğan", "TR080099909332004101851568", "00000000-0000-0000-0001-000000000044", "Annem" },
                    { 169, "Yusuf Doğan", "TR860099909743004201282065", "00000000-0000-0000-0001-000000000044", "Babam" },
                    { 170, "Ozan Doğan", "TR280099907035004301307654", "00000000-0000-0000-0001-000000000044", "Abim" },
                    { 171, "Tolga Kılıç", "TR920099907549004601396183", "00000000-0000-0000-0001-000000000045", "Eşim" },
                    { 172, "Mert Kılıç", "TR930099904179004701278046", "00000000-0000-0000-0001-000000000045", "Oğlum" },
                    { 173, "Derya Koç", "TR790099905261004801886142", "00000000-0000-0000-0001-000000000045", "Derya" },
                    { 174, "Filiz Doğan", "TR080099909332004101851568", "00000000-0000-0000-0001-000000000045", "Filiz" },
                    { 175, "Esra Kılıç", "TR710099903646004501221252", "00000000-0000-0000-0001-000000000046", "Eşim" },
                    { 176, "Mert Kılıç", "TR930099904179004701278046", "00000000-0000-0000-0001-000000000046", "Oğlum" },
                    { 177, "Mustafa Yılmaz", "TR520099901210000201851762", "00000000-0000-0000-0001-000000000046", "Mustafa" },
                    { 178, "Kemal Arslan", "TR940099902179003901851260", "00000000-0000-0000-0001-000000000046", "Kemal" },
                    { 179, "Esra Kılıç", "TR710099903646004501221252", "00000000-0000-0000-0001-000000000047", "Annem" },
                    { 180, "Tolga Kılıç", "TR920099907549004601396183", "00000000-0000-0000-0001-000000000047", "Babam" },
                    { 181, "Ada Koç", "TR590099907439005001556086", "00000000-0000-0000-0001-000000000047", "Ada" },
                    { 182, "Ozan Doğan", "TR280099907035004301307654", "00000000-0000-0000-0001-000000000047", "Ozan" },
                    { 183, "Volkan Koç", "TR180099906097004901966997", "00000000-0000-0000-0001-000000000048", "Eşim" },
                    { 184, "Ada Koç", "TR590099907439005001556086", "00000000-0000-0000-0001-000000000048", "Kızım" },
                    { 185, "Fatma Yılmaz", "TR820099902999000101813166", "00000000-0000-0000-0001-000000000048", "Fatma" },
                    { 186, "Esra Kılıç", "TR710099903646004501221252", "00000000-0000-0000-0001-000000000048", "Esra" },
                    { 187, "Derya Koç", "TR790099905261004801886142", "00000000-0000-0000-0001-000000000049", "Eşim" },
                    { 188, "Ada Koç", "TR590099907439005001556086", "00000000-0000-0000-0001-000000000049", "Kızım" },
                    { 189, "Mehmet Kaya", "TR270099905613000601131315", "00000000-0000-0000-0001-000000000049", "Mehmet" },
                    { 190, "Yusuf Doğan", "TR860099909743004201282065", "00000000-0000-0000-0001-000000000049", "Yusuf" },
                    { 191, "Derya Koç", "TR790099905261004801886142", "00000000-0000-0000-0001-000000000050", "Annem" },
                    { 192, "Volkan Koç", "TR180099906097004901966997", "00000000-0000-0000-0001-000000000050", "Babam" },
                    { 193, "Ayşe Yılmaz", "TR260099907181000301488803", "00000000-0000-0000-0001-000000000050", "Ayşe" },
                    { 194, "Mert Kılıç", "TR930099904179004701278046", "00000000-0000-0000-0001-000000000050", "Mert" }
                });

            migrationBuilder.InsertData(
                table: "KullaniciRolleri",
                columns: new[] { "RolId", "KullaniciId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000001" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000002" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000003" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000004" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000005" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000006" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000007" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000008" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000009" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000010" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000011" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000012" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000013" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000014" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000015" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000016" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000017" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000018" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000019" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000020" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000021" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000022" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000023" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000024" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000025" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000026" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000027" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000028" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000029" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000030" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000031" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000032" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000033" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000034" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000035" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000036" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000037" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000038" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000039" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000040" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000041" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000042" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000043" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000044" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000045" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000046" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000047" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000048" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000049" },
                    { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000050" },
                    { "00000000-0000-0000-0003-000000000002", "00000000-0000-0000-0002-000000000001" }
                });

            migrationBuilder.InsertData(
                table: "Islemler",
                columns: new[] { "Id", "Aciklama", "AliciIban", "Durum", "HesapId", "IslemTuru", "Kanal", "Tarih", "Tutar" },
                values: new object[,]
                {
                    { 1, "Başlangıç parası", null, 1, 1, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 33000m },
                    { 2, "Başlangıç parası", null, 1, 2, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 86000m },
                    { 3, "Başlangıç parası", null, 1, 3, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 49000m },
                    { 4, "Başlangıç parası", null, 1, 4, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 10000m },
                    { 5, "Başlangıç parası", null, 1, 5, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 75500m },
                    { 6, "Başlangıç parası", null, 1, 6, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 63500m },
                    { 7, "Başlangıç parası", null, 1, 7, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 119500m },
                    { 8, "Başlangıç parası", null, 1, 8, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 15500m },
                    { 9, "Başlangıç parası", null, 1, 9, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 19000m },
                    { 10, "Başlangıç parası", null, 1, 10, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 116000m },
                    { 11, "Başlangıç parası", null, 1, 11, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6500m },
                    { 12, "Başlangıç parası", null, 1, 12, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5000m },
                    { 13, "Başlangıç parası", null, 1, 13, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 96000m },
                    { 14, "Başlangıç parası", null, 1, 14, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 108000m },
                    { 15, "Başlangıç parası", null, 1, 15, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 61000m },
                    { 16, "Başlangıç parası", null, 1, 16, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 40000m },
                    { 17, "Başlangıç parası", null, 1, 17, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 57000m },
                    { 18, "Başlangıç parası", null, 1, 18, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 32000m },
                    { 19, "Başlangıç parası", null, 1, 19, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 39500m },
                    { 20, "Başlangıç parası", null, 1, 20, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 122000m },
                    { 21, "Başlangıç parası", null, 1, 21, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 121000m },
                    { 22, "Başlangıç parası", null, 1, 22, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 85000m },
                    { 23, "Başlangıç parası", null, 1, 23, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 85000m },
                    { 24, "Başlangıç parası", null, 1, 24, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 58500m },
                    { 25, "Başlangıç parası", null, 1, 25, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 67500m },
                    { 26, "Başlangıç parası", null, 1, 26, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 53500m },
                    { 27, "Başlangıç parası", null, 1, 27, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 80500m },
                    { 28, "Başlangıç parası", null, 1, 28, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 27000m },
                    { 29, "Başlangıç parası", null, 1, 29, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 65500m },
                    { 30, "Başlangıç parası", null, 1, 30, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 97000m },
                    { 31, "Başlangıç parası", null, 1, 31, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 112000m },
                    { 32, "Başlangıç parası", null, 1, 32, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 113000m },
                    { 33, "Başlangıç parası", null, 1, 33, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 115000m },
                    { 34, "Başlangıç parası", null, 1, 34, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 137000m },
                    { 35, "Başlangıç parası", null, 1, 35, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 90500m },
                    { 36, "Başlangıç parası", null, 1, 36, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 110500m },
                    { 37, "Başlangıç parası", null, 1, 37, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 91500m },
                    { 38, "Başlangıç parası", null, 1, 38, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 7500m },
                    { 39, "Başlangıç parası", null, 1, 39, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 25000m },
                    { 40, "Başlangıç parası", null, 1, 40, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 48500m },
                    { 41, "Başlangıç parası", null, 1, 41, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 119000m },
                    { 42, "Başlangıç parası", null, 1, 42, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 77500m },
                    { 43, "Başlangıç parası", null, 1, 43, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 148000m },
                    { 44, "Başlangıç parası", null, 1, 44, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 148500m },
                    { 45, "Başlangıç parası", null, 1, 45, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 139500m },
                    { 46, "Başlangıç parası", null, 1, 46, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 19500m },
                    { 47, "Başlangıç parası", null, 1, 47, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 38000m },
                    { 48, "Başlangıç parası", null, 1, 48, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 30500m },
                    { 49, "Başlangıç parası", null, 1, 49, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 101500m },
                    { 50, "Başlangıç parası", null, 1, 50, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 36500m },
                    { 51, "Başlangıç parası", null, 1, 51, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 33000m },
                    { 52, "Başlangıç parası", null, 1, 52, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 99000m },
                    { 53, "Başlangıç parası", null, 1, 53, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 26500m },
                    { 54, "Başlangıç parası", null, 1, 54, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 17500m },
                    { 55, "Başlangıç parası", null, 1, 55, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 16000m },
                    { 56, "Başlangıç parası", null, 1, 56, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 17000m },
                    { 57, "Başlangıç parası", null, 1, 57, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 30500m },
                    { 58, "Başlangıç parası", null, 1, 58, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 147000m },
                    { 59, "Başlangıç parası", null, 1, 59, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 53500m },
                    { 60, "Başlangıç parası", null, 1, 60, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 143500m },
                    { 61, "Başlangıç parası", null, 1, 61, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 125500m },
                    { 62, "Başlangıç parası", null, 1, 62, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 33500m },
                    { 63, "Başlangıç parası", null, 1, 63, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 97500m },
                    { 64, "Başlangıç parası", null, 1, 64, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 142500m },
                    { 65, "Başlangıç parası", null, 1, 65, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 104000m },
                    { 66, "Başlangıç parası", null, 1, 66, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 53500m },
                    { 67, "Başlangıç parası", null, 1, 67, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 72000m },
                    { 68, "Başlangıç parası", null, 1, 68, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 39500m },
                    { 69, "Başlangıç parası", null, 1, 69, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 66500m },
                    { 70, "Başlangıç parası", null, 1, 70, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 112500m },
                    { 71, "Başlangıç parası", null, 1, 71, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 42500m },
                    { 72, "Başlangıç parası", null, 1, 72, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 109000m },
                    { 73, "Başlangıç parası", null, 1, 73, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 93500m },
                    { 74, "Başlangıç parası", null, 1, 74, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 115500m },
                    { 75, "Başlangıç parası", null, 1, 75, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 64000m },
                    { 76, "Başlangıç parası", null, 1, 76, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 106000m },
                    { 77, "Başlangıç parası", null, 1, 77, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 130000m },
                    { 78, "Başlangıç parası", null, 1, 78, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 103500m },
                    { 79, "Başlangıç parası", null, 1, 79, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 65000m },
                    { 80, "Başlangıç parası", null, 1, 80, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 99500m },
                    { 81, "Başlangıç parası", null, 1, 81, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5500m },
                    { 82, "Başlangıç parası", null, 1, 82, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 54500m },
                    { 83, "Başlangıç parası", null, 1, 83, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 32500m },
                    { 84, "Başlangıç parası", null, 1, 84, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 96500m },
                    { 85, "Başlangıç parası", null, 1, 85, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 42500m },
                    { 86, "Başlangıç parası", null, 1, 86, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 64500m },
                    { 87, "Başlangıç parası", null, 1, 87, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 13000m },
                    { 88, "Başlangıç parası", null, 1, 88, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 105500m },
                    { 89, "Başlangıç parası", null, 1, 89, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 112500m },
                    { 90, "Başlangıç parası", null, 1, 90, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 21500m },
                    { 91, "Başlangıç parası", null, 1, 91, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 130000m },
                    { 92, "Başlangıç parası", null, 1, 92, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 58500m },
                    { 93, "Başlangıç parası", null, 1, 93, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 117500m },
                    { 94, "Başlangıç parası", null, 1, 94, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 50500m },
                    { 95, "Başlangıç parası", null, 1, 95, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 6500m },
                    { 96, "Başlangıç parası", null, 1, 96, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 19000m },
                    { 97, "Başlangıç parası", null, 1, 97, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 47500m },
                    { 98, "Başlangıç parası", null, 1, 98, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 149500m },
                    { 99, "Başlangıç parası", null, 1, 99, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 94000m },
                    { 100, "Başlangıç parası", null, 1, 100, 1, 0, new DateTime(2026, 8, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 59000m },
                    { 101, "Kart borcu ödemesi (5412 **** **** 5873)", null, 1, 5, 2, 0, new DateTime(2026, 8, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), 1950m },
                    { 102, "Kart borcu ödemesi (5412 **** **** 5873)", null, 1, 5, 2, 0, new DateTime(2026, 9, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), 1650m },
                    { 103, "Kart borcu ödemesi (5412 **** **** 5411)", null, 1, 7, 2, 0, new DateTime(2026, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), 550m },
                    { 104, "Kart borcu ödemesi (5412 **** **** 0459)", null, 1, 9, 2, 0, new DateTime(2026, 8, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 1900m },
                    { 105, "Kart borcu ödemesi (5412 **** **** 9457)", null, 1, 17, 2, 0, new DateTime(2026, 8, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 1400m },
                    { 106, "Kart borcu ödemesi (5412 **** **** 9457)", null, 1, 17, 2, 0, new DateTime(2026, 8, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), 2150m },
                    { 107, "Kart borcu ödemesi (5412 **** **** 7608)", null, 1, 19, 2, 0, new DateTime(2026, 9, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 3700m },
                    { 108, "Kart borcu ödemesi (5412 **** **** 7608)", null, 1, 19, 2, 0, new DateTime(2026, 9, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), 1100m },
                    { 109, "Kart borcu ödemesi (5412 **** **** 7847)", null, 1, 23, 2, 0, new DateTime(2026, 10, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), 3300m },
                    { 110, "Kart borcu ödemesi (5412 **** **** 5323)", null, 1, 25, 2, 0, new DateTime(2026, 9, 11, 17, 0, 0, 0, DateTimeKind.Unspecified), 4300m },
                    { 111, "Kart borcu ödemesi (5412 **** **** 5323)", null, 1, 25, 2, 0, new DateTime(2026, 9, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), 4550m },
                    { 112, "Kart borcu ödemesi (5412 **** **** 7064)", null, 1, 27, 2, 0, new DateTime(2026, 8, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), 2600m },
                    { 113, "Kart borcu ödemesi (5412 **** **** 7064)", null, 1, 27, 2, 0, new DateTime(2026, 10, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 750m },
                    { 114, "Kart borcu ödemesi (5412 **** **** 4283)", null, 1, 29, 2, 0, new DateTime(2026, 9, 11, 16, 0, 0, 0, DateTimeKind.Unspecified), 950m },
                    { 115, "Kart borcu ödemesi (5412 **** **** 4283)", null, 1, 29, 2, 0, new DateTime(2026, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), 3650m },
                    { 116, "Kart borcu ödemesi (5412 **** **** 5210)", null, 1, 39, 2, 0, new DateTime(2026, 9, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 5000m },
                    { 117, "Kart borcu ödemesi (5412 **** **** 4857)", null, 1, 47, 2, 0, new DateTime(2026, 9, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), 750m },
                    { 118, "Kart borcu ödemesi (5412 **** **** 4857)", null, 1, 47, 2, 0, new DateTime(2026, 9, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), 800m },
                    { 119, "Kart borcu ödemesi (5412 **** **** 5245)", null, 1, 51, 2, 0, new DateTime(2026, 9, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), 2800m },
                    { 120, "Kart borcu ödemesi (5412 **** **** 2055)", null, 1, 59, 2, 0, new DateTime(2026, 9, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), 3000m },
                    { 121, "Kart borcu ödemesi (5412 **** **** 2055)", null, 1, 59, 2, 0, new DateTime(2026, 10, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 5000m },
                    { 122, "Kart borcu ödemesi (5412 **** **** 5405)", null, 1, 63, 2, 0, new DateTime(2026, 10, 10, 20, 0, 0, 0, DateTimeKind.Unspecified), 2300m },
                    { 123, "Kart borcu ödemesi (5412 **** **** 0014)", null, 1, 65, 2, 0, new DateTime(2026, 9, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), 3000m },
                    { 124, "Kart borcu ödemesi (5412 **** **** 4235)", null, 1, 69, 2, 0, new DateTime(2026, 8, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), 4650m },
                    { 125, "Kart borcu ödemesi (5412 **** **** 0498)", null, 1, 71, 2, 0, new DateTime(2026, 8, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 3550m },
                    { 126, "Kart borcu ödemesi (5412 **** **** 7816)", null, 1, 73, 2, 0, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), 4550m },
                    { 127, "Kart borcu ödemesi (5412 **** **** 7816)", null, 1, 73, 2, 0, new DateTime(2026, 9, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), 4000m },
                    { 128, "Kart borcu ödemesi (5412 **** **** 8378)", null, 1, 75, 2, 0, new DateTime(2026, 8, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), 550m },
                    { 129, "Kart borcu ödemesi (5412 **** **** 4791)", null, 1, 83, 2, 0, new DateTime(2026, 9, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 1150m },
                    { 130, "Kart borcu ödemesi (5412 **** **** 4791)", null, 1, 83, 2, 0, new DateTime(2026, 10, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), 700m },
                    { 131, "Kart borcu ödemesi (5412 **** **** 1777)", null, 1, 89, 2, 0, new DateTime(2026, 9, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), 1600m },
                    { 132, "Kart borcu ödemesi (5412 **** **** 8083)", null, 1, 93, 2, 0, new DateTime(2026, 10, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), 2250m },
                    { 133, "Kart borcu ödemesi (5412 **** **** 7265)", null, 1, 95, 2, 0, new DateTime(2026, 9, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 2750m },
                    { 134, "Kart borcu ödemesi (5412 **** **** 7265)", null, 1, 95, 2, 0, new DateTime(2026, 10, 7, 21, 0, 0, 0, DateTimeKind.Unspecified), 2350m },
                    { 135, "Kart borcu ödemesi (5412 **** **** 5024)", null, 1, 97, 2, 0, new DateTime(2026, 9, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), 3650m },
                    { 136, "Kart borcu ödemesi (5412 **** **** 6903)", null, 1, 99, 2, 0, new DateTime(2026, 10, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), 700m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Islemler",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Kartlar",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "KayitliAlicilar",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000001" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000002" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000003" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000004" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000005" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000006" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000007" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000008" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000009" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000010" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000011" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000012" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000013" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000014" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000015" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000016" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000017" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000018" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000019" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000020" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000021" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000022" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000023" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000024" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000025" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000026" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000027" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000028" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000029" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000030" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000031" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000032" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000033" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000034" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000035" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000036" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000037" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000038" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000039" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000040" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000041" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000042" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000043" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000044" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000045" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000046" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000047" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000048" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000049" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000001", "00000000-0000-0000-0001-000000000050" });

            migrationBuilder.DeleteData(
                table: "KullaniciRolleri",
                keyColumns: new[] { "RolId", "KullaniciId" },
                keyValues: new object[] { "00000000-0000-0000-0003-000000000002", "00000000-0000-0000-0002-000000000001" });

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Hesaplar",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0002-000000000001");

            migrationBuilder.DeleteData(
                table: "Roller",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0003-000000000001");

            migrationBuilder.DeleteData(
                table: "Roller",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0003-000000000002");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000001");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000002");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000003");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000004");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000005");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000006");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000007");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000008");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000009");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000010");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000011");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000012");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000013");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000014");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000015");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000016");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000017");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000018");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000019");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000020");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000021");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000022");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000023");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000024");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000025");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000026");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000027");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000028");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000029");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000030");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000031");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000032");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000033");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000034");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000035");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000036");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000037");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000038");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000039");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000040");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000041");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000042");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000043");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000044");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000045");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000046");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000047");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000048");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000049");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0001-000000000050");
        }
    }
}
