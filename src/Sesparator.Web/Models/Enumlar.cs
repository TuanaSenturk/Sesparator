namespace Sesparator.Web.Models;

public enum HesapTuru
{
    Vadesiz,
    Vadeli
}

public enum IslemTuru
{
    GidenTransfer,
    GelenTransfer,
    KartBorcOdeme
}

public enum IslemKanali
{
    Web,
    Ses
}

public enum IslemDurumu
{
    Beklemede,
    Tamamlandi,
    IptalEdildi,
    Basarisiz
}
