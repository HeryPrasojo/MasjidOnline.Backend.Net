
using MasjidOnline.Business.User.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.User;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IUserAddInternalBusiness, UserAddInternalBusiness>();
        services.AddSingleton<IInitializerBusiness, InitializerBusiness>();
        services.AddSingleton<IUserSetPasswordBusiness, UserSetPasswordBusiness>();

        return services;
    }
}
