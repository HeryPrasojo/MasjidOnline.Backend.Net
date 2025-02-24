namespace MasjidOnline.Service.Mail.Interface.Model;

public class MailOptions
{
    public required string DefaultFromAddress { get; set; }
    public required string DefaultFromName { get; set; }

    public required string SmtpHost { get; set; }
    public required int SmtpPort { get; set; }
    public required string SmtpUserName { get; set; }
    public required string SmtpUserPassword { get; set; }
}
