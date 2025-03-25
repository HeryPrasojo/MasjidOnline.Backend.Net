using MasjidOnline.Service.Captcha.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service.Captcha;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCaptchaService(this IServiceCollection services)
    {
        services.AddSingleton<ICaptchaService, MasjidOnline.Service.Captcha.ReCaptcha.CaptchaService>();

        return services;
    }

}
