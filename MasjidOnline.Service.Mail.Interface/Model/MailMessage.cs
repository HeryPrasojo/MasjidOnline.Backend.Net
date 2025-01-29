using System.Collections.Generic;

namespace MasjidOnline.Service.Mail.Interface.Model;

public class MailMessage
{
    public required string Subject { get; set; }

    public required IEnumerable<MailAddress> To { get; set; }

    public IEnumerable<MailAddress>? Cc { get; set; }

    public IEnumerable<MailAddress>? Bcc { get; set; }

    public required string BodyHtml { get; set; }

    public required string BodyText { get; set; }

    public IEnumerable<Attachment>? Attachments { get; set; }

    public MailAddress? From { get; set; }
}
