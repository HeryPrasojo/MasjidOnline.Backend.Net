using MasjidOnline.Service.Captcha.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service.Captcha.ReCaptcha;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddReCaptchaService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<GoogleOptions>(configuration.GetSection("Google"));

        services.AddSingleton<ICaptchaService, CaptchaService>();

        return services;
    }

}
