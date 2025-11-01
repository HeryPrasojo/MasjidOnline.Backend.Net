using System;
using System.Collections.Generic;
using System.Net.Http;
using MasjidOnline.Service.Captcha.ReCaptcha;
using MasjidOnline.Service.Cryptography;
using MasjidOnline.Service.Cryptography.Interface.Model;
using MasjidOnline.Service.FieldValidator;
using MasjidOnline.Service.File;
using MasjidOnline.Service.Hash;
using MasjidOnline.Service.Interface;
using MasjidOnline.Service.Localization;
using MasjidOnline.Service.Mail.Interface.Model;
using MasjidOnline.Service.Mail.MailKit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Service;

public class Service : IService
{
    private readonly CaptchaService _captchaService;
    private readonly Encryption128b256kService _encryption128b256kService;
    private readonly FieldValidatorService _fieldValidatorService;
    private readonly FileService _fileService;
    private readonly Hash128Service _hash128Service;
    private readonly Hash256Service _hash256Service;
    private readonly Hash512Service _hash512Service;
    private readonly LocalizationService _localizationService;
    private readonly SmtpMailSenderService _mailSenderService;

    public Service(
        IHostEnvironment hostEnvironment,
        IHttpClientFactory httpClientFactory,
        IOptionsMonitor<CryptographyOptions> cryptographyOption,
        IOptionsMonitor<GoogleOptions> googleOptions,
        IOptionsMonitor<MailOptions> mailOption)
    {
        if (cryptographyOption.CurrentValue.Key256Base64 == default)
            throw new ApplicationException($"{nameof(CryptographyOptions)}.{nameof(CryptographyOptions.Key256Base64)} is not found");

        var isEnvironmentDevelopment = hostEnvironment.IsDevelopment();

        _fieldValidatorService = new();
        _fileService = new();
        _hash128Service = new();
        _hash256Service = new();
        _hash512Service = new();
        _localizationService = new();

        _captchaService = new(!isEnvironmentDevelopment, httpClientFactory, googleOptions);
        _encryption128b256kService = new(cryptographyOption, _hash256Service);
        _mailSenderService = new(mailOption);
    }

    public Captcha.Interface.ICaptchaService Captcha => _captchaService;
    public Cryptography.Interface.IEncryption128b256kService Encryption128b256kService => _encryption128b256kService;
    public FieldValidator.Interface.IFieldValidatorService FieldValidator => _fieldValidatorService;
    public File.Interface.IFileService File => _fileService;
    public Hash.Interface.IHash128Service Hash128 => _hash128Service;
    public Hash.Interface.IHash512Service Hash512 => _hash512Service;
    public Mail.Interface.IMailSenderService MailSender => _mailSenderService;
    public Localization.Interface.ILocalizationService Localization => _localizationService;

    public void Initialize(IEnumerable<string> createDirectories)
    {
        Captcha.Initialize();
        File.Initialize(createDirectories);
    }
}
