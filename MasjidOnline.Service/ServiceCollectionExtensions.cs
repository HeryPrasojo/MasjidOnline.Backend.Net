using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<UserSession>();

        return services;
    }
}
