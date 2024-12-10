using MasjidOnline.Business.Interface.User;
using MasjidOnline.Business.User;
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
