using MasjidOnline.Business.Authorization;
using MasjidOnline.Business.Captcha;
using MasjidOnline.Business.Infaq;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Session;
using MasjidOnline.Business.User;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IBusiness, Business>();

        services.AddAuthorizationBusiness();
        services.AddCaptchaBusiness();
        services.AddInfaqBusiness();
        services.AddSessionBusiness();
        services.AddUserBusiness();

        return services;
    }
}
