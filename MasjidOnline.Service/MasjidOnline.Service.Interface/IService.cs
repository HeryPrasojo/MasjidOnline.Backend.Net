using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.Cryptography.Interface;
using MasjidOnline.Service.FieldValidator.Interface;
using MasjidOnline.Service.Hash.Interface;
using MasjidOnline.Service.Mail.Interface;

namespace MasjidOnline.Service.Interface;

public interface IService
{
    ICaptchaService Captcha { get; }
    IEncryption128128Service Encryption128128 { get; }
    IFieldValidatorService FieldValidator { get; }
    IHash128Service Hash128 { get; }
    IHash512Service Hash512 { get; }
    IMailSenderService MailSender { get; }
}
