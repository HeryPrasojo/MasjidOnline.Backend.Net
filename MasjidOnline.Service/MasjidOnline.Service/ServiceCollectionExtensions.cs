using MasjidOnline.Service.Captcha.ReCaptcha;
using MasjidOnline.Service.Cryptography;
using MasjidOnline.Service.FieldValidator;
using MasjidOnline.Service.Hash;
using MasjidOnline.Service.Mail.MailKit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCryptographyService(configuration);
        services.AddFieldValidatorService();
        services.AddHashService();
        services.AddMailKitMailService(configuration);
        services.AddReCaptchaService(configuration);

        return services;
    }
}
