using System.Net.Http;
using MasjidOnline.Service.Captcha.ReCaptcha;
using MasjidOnline.Service.Interface;
using MasjidOnline.Service.Localization.Strings;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Service;

public class Service(
    IHttpClientFactory _httpClientFactory,
    IOptions<Cryptography.Interface.Model.CryptographyOptions> _cryptographyOptions,
    IOptionsMonitor<GoogleOptions> _googleOptions,
    IOptionsMonitor<MailOptions> _mailOptions) : IService
{
    private static readonly Hash.Interface.IHash128Service _hash128Service = new Hash.Hash128Service();


    public Captcha.Interface.ICaptchaService Captcha { get; } = new CaptchaService(_httpClientFactory, _googleOptions);

    public Cryptography.Interface.IEncryption128128Service Encryption128128 { get; } = new Cryptography.Encryption128128Service(_cryptographyOptions, _hash128Service);

    public FieldValidator.Interface.IFieldValidatorService FieldValidator { get; } = new FieldValidator.FieldValidatorService();

    public File.Interface.IFileService File { get; } = new File.FileService();

    public Hash.Interface.IHash128Service Hash128 { get; } = _hash128Service;

    public Hash.Interface.IHash512Service Hash512 { get; } = new Hash.Hash512Service();

    public Mail.Interface.IMailSenderService MailSender { get; } = new Mail.MailKit.SmtpMailSenderService(_mailOptions);

    public Localization.Interface.ILocalizationService Localization { get; } = new Localization.LocalizationService(new Localization.LocalizationStringService(new PaymentStatusService()));
}
