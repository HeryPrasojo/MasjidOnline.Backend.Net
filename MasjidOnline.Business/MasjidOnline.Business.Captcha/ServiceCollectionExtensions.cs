using MasjidOnline.Business.Captcha.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Captcha;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCaptchaBusiness(this IServiceCollection services)
    {
        services.AddSingleton<ICaptchaAddBusiness, CaptchaAddBusiness>();

        services.AddSingleton<ICaptchaUpdateBusiness, CaptchaUpdateBusiness>();

        return services;
    }
}
