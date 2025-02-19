namespace MasjidOnline.Data.Interface.Model.Options;

public class ConnectionStrings
{
    public string Audit { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";

    public string Captcha { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";

    public string Core { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";

    public string Event { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";

    public string Infaqs { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";

    public string Sessions { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";

    public string Users { get; set; } = "Data Source=..\\..\\MasjidOnline.Local.sqlite3;";
}
