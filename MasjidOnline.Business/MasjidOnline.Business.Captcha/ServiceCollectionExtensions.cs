using MasjidOnline.Business.Captcha.Captcha;
using MasjidOnline.Business.Captcha.Interface.Captcha;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Captcha;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCaptchaBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IAddBusiness, AddBusiness>();

        services.AddSingleton<IUpdateBusiness, UpdateBusiness>();

        return services;
    }
}
