using System.Collections.Generic;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.Cryptography.Interface;
using MasjidOnline.Service.FieldValidator.Interface;
using MasjidOnline.Service.File.Interface;
using MasjidOnline.Service.Hash.Interface;
using MasjidOnline.Service.Localization.Interface;
using MasjidOnline.Service.Mail.Interface;

namespace MasjidOnline.Service.Interface;

public interface IService
{
    ICaptchaService Captcha { get; }
    IEncryption128b256kService Encryption128b256kService { get; }
    IFieldValidatorService FieldValidator { get; }
    IHash128Service Hash128 { get; }
    IHash512Service Hash512 { get; }
    IMailSenderService MailSender { get; }
    IFileService File { get; }
    ILocalizationService Localization { get; }

    void Initialize(IEnumerable<string> createDirectories);
}
