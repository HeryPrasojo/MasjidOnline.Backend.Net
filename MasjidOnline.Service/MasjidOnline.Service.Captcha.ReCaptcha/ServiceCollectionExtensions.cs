using MasjidOnline.Service.Captcha.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service.Captcha.ReCaptcha;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddReCaptchaService(this IServiceCollection services)
    {
        services.AddSingleton<ICaptchaService, CaptchaService>();

        return services;
    }

}
