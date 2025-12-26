using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Session;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSessionBusiness(this IServiceCollection services)
    {
        services.AddScoped<Model.Session.Session>();

        return services;
    }
}
