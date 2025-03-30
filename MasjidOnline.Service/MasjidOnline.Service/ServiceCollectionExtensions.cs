using MasjidOnline.Service.Captcha.ReCaptcha;
using MasjidOnline.Service.Cryptography.Interface.Model;
using MasjidOnline.Service.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CryptographyOptions>(configuration.GetSection("Cryptography"));
        services.Configure<MailOptions>(configuration.GetSection("Mail"));
        services.Configure<GoogleOptions>(configuration.GetSection("Google"));

        services.AddSingleton<IService, Service>();

        return services;
    }
}
