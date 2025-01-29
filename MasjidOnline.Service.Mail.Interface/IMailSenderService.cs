using System.Threading.Tasks;
using MasjidOnline.Service.Mail.Interface.Model;

namespace MasjidOnline.Service.Mail.Interface;

public interface IMailSenderService
{
    Task SendMailAsync(MailMessage mailMessage);
}
