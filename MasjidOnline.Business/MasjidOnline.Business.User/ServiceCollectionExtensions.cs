using MasjidOnline.Business.User.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.User;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserBusiness(this IServiceCollection services)
    {
        // todo change all transient to scoped
        services.AddTransient<IInitializerBusiness, InitializerBusiness>();

        return services;
    }
}
