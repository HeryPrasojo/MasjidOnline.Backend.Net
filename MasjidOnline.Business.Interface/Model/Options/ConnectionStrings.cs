namespace MasjidOnline.Business.Interface.Model.Options;

public class ConnectionStrings
{
    public string Audit { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";

    public string Captcha { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";

    public string Core { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";

    public string Event { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";

    public string Transaction { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";

    public string User { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";
}
