namespace MasjidOnline.Service.Mail.Interface.Model;

public class MailOptions
{
    public string DefaultFromAddress { get; set; } = "system.dev@dev.masjidonline.org";
    public string DefaultFromName { get; set; } = "MasjidOnline System";

    public string SmtpHost { get; set; } = "dev.masjidonline.org";
    public int SmtpPort { get; set; } = 587;
    public string SmtpUserName { get; set; } = "dev.masjidonline.org";
    public string SmtpUserPassword { get; set; } = "";
}
