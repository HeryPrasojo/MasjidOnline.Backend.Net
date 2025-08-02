using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Session;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSessionBusiness(this IServiceCollection services)
    {
        services.AddScoped<Interface.Model.Session>();

        return services;
    }
}
