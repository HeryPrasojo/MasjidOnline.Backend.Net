using System.Collections.Generic;
using System.Net.Http;
using MasjidOnline.Service.Captcha.ReCaptcha;
using MasjidOnline.Service.Cryptography;
using MasjidOnline.Service.FieldValidator;
using MasjidOnline.Service.File;
using MasjidOnline.Service.Hash;
using MasjidOnline.Service.Interface;
using MasjidOnline.Service.Localization;
using MasjidOnline.Service.Mail.Interface.Model;
using MasjidOnline.Service.Mail.MailKit;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Service;

public class Service(
    IHttpClientFactory httpClientFactory,
    IOptions<Cryptography.Interface.Model.CryptographyOptions> cryptographyOptions,
    IOptionsMonitor<GoogleOptions> googleOptions,
    IOptionsMonitor<MailOptions> mailOptions) : IService
{
    private static readonly Hash128Service _hash128Service = new();

    private readonly CaptchaService _captchaService = new(httpClientFactory, googleOptions);
    private readonly Encryption128128Service _encryption128128Service = new(cryptographyOptions, _hash128Service);
    private readonly FieldValidatorService _fieldValidatorService = new();
    private readonly FileService _fileService = new();
    private readonly Hash512Service _hash512Service = new();
    private readonly SmtpMailSenderService _mailSenderService = new(mailOptions);
    private readonly LocalizationService _localizationService = new();

    public Captcha.Interface.ICaptchaService Captcha => _captchaService;
    public Cryptography.Interface.IEncryption128128Service Encryption128128 => _encryption128128Service;
    public FieldValidator.Interface.IFieldValidatorService FieldValidator => _fieldValidatorService;
    public File.Interface.IFileService File => _fileService;
    public Hash.Interface.IHash128Service Hash128 => _hash128Service;
    public Hash.Interface.IHash512Service Hash512 => _hash512Service;
    public Mail.Interface.IMailSenderService MailSender => _mailSenderService;
    public Localization.Interface.ILocalizationService Localization => _localizationService;

    public void Initialize(IEnumerable<string> createDirectories)
    {
        _captchaService.Initialize();
        _fileService.Initialize(createDirectories);
    }
}
