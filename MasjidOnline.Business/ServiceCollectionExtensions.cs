using MasjidOnline.Business.Authentication;
using MasjidOnline.Business.Interface.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddSingleton<ILoginBusiness, LoginBusiness>();

        return services;
    }
}
