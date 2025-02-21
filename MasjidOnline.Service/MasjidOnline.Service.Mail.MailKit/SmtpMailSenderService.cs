using System.Threading.Tasks;
using MasjidOnline.Service.Mail.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MasjidOnline.Service.Mail.MailKit;

public class SmtpMailSenderService(IOptionsMonitor<MailOptions> _optionsMonitor) : IMailSenderService
{
    // hack create queue when fail
    public async Task SendMailAsync(MailMessage mailMessage)
    {
        var mailOption = _optionsMonitor.CurrentValue;

        var bodyBuilder = new BodyBuilder()
        {
            HtmlBody = mailMessage.BodyHtml,
            TextBody = mailMessage.BodyText,
        };

        if (mailMessage.Attachments != default)
        {
            foreach (var attachment in mailMessage.Attachments)
            {
                var contentType = new ContentType(attachment.ContentType, attachment.ContentSubType);

                await bodyBuilder.Attachments.AddAsync(attachment.Name, attachment.Stream, contentType);
            }
        }

        var mimeMessage = new MimeMessage()
        {
            Body = bodyBuilder.ToMessageBody(),
            Subject = mailMessage.Subject,
        };

        foreach (var to in mailMessage.To)
        {
            var mailboxAddress = new MailboxAddress(to.Name, to.Address);

            mimeMessage.To.Add(mailboxAddress);
        }

        if (mailMessage.Cc != default)
        {
            foreach (var cc in mailMessage.Cc)
            {
                var mailboxAddress = new MailboxAddress(cc.Name, cc.Address);

                mimeMessage.Cc.Add(mailboxAddress);
            }
        }

        if (mailMessage.Bcc != default)
        {
            foreach (var bcc in mailMessage.Bcc)
            {
                var mailboxAddress = new MailboxAddress(bcc.Name, bcc.Address);

                mimeMessage.Bcc.Add(mailboxAddress);
            }
        }

        if (mailMessage.From != default)
        {
            var mailboxAddress = new MailboxAddress(mailMessage.From.Name, mailMessage.From.Address);

            mimeMessage.From.Add(mailboxAddress);
        }
        else
        {
            var mailboxAddress = new MailboxAddress(mailOption.DefaultFromName, mailOption.DefaultFromAddress);

            mimeMessage.From.Add(mailboxAddress);
        }


        // todo mail

        //using var smtpClient = new SmtpClient();

        //await smtpClient.ConnectAsync(mailOption.SmtpHost, mailOption.SmtpPort, SecureSocketOptions.StartTlsWhenAvailable);

        //await smtpClient.AuthenticateAsync(mailOption.SmtpUserName, mailOption.SmtpUserPassword);

        //await smtpClient.SendAsync(mimeMessage);

        //await smtpClient.DisconnectAsync(true);
    }
}
