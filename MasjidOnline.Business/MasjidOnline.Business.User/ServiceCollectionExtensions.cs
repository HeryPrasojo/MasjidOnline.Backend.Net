
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Business.User.Internal;
using MasjidOnline.Business.User.User;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.User;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IAddBusiness, AddBusiness>();
        services.AddSingleton<IInitializerBusiness, InitializerBusiness>();
        services.AddSingleton<IUserSetPasswordBusiness, UserSetPasswordBusiness>();

        return services;
    }
}
