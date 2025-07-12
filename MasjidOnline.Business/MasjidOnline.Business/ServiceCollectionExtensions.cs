using MasjidOnline.Business.Authorization;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Session;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<BusinessOptions>(configuration);

        services.AddSingleton<IBusiness, Business>();

        services.AddAuthorizationBusiness();
        services.AddSessionBusiness();

        return services;
    }
}
