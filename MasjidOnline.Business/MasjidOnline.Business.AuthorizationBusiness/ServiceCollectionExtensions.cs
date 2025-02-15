using MasjidOnline.Business.AuthorizationBusiness.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.AuthorizationBusiness;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAuthorizationBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationBusiness, AuthorizationBusiness>();

        return services;
    }
}
