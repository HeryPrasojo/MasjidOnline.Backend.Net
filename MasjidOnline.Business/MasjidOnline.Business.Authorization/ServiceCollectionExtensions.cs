using MasjidOnline.Business.Authorization.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Authorization;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthorizationBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationBusiness, AuthorizationBusiness>();

        return services;
    }
}
