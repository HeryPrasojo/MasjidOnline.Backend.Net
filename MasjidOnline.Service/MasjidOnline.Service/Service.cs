using System.Net.Http;
using MasjidOnline.Service.Captcha.ReCaptcha;
using MasjidOnline.Service.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Service;

public class Service(
    IHttpClientFactory _httpClientFactory,
    IOptions<Cryptography.Interface.Model.CryptographyOptions> _cryptographyOptions,
    IOptionsMonitor<GoogleOptions> _googleOptions,
    IOptionsMonitor<MailOptions> _mailOptions) : IService
{
    private Hash.Interface.IHash128Service _hash128Service = new Hash.Hash128Service();

    private Cryptography.Interface.IEncryption128128Service? _encryption128128Service;


    public Captcha.Interface.ICaptchaService Captcha => new Captcha.ReCaptcha.CaptchaService(_httpClientFactory, _googleOptions);

    public Cryptography.Interface.IEncryption128128Service Encryption128128 => _encryption128128Service ??= new Cryptography.Encryption128128Service(_cryptographyOptions, _hash128Service);

    public FieldValidator.Interface.IFieldValidatorService FieldValidator => new FieldValidator.FieldValidatorService();

    public Hash.Interface.IHash128Service Hash128 => _hash128Service;

    public Hash.Interface.IHash512Service Hash512 => new Hash.Hash512Service();

    public Mail.Interface.IMailSenderService MailSender => new Mail.MailKit.SmtpMailSenderService(_mailOptions);
}
