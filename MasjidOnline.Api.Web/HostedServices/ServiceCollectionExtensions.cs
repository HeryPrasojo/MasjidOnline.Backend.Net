using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Api.Web.HostedServices;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHostedServices(this IServiceCollection services)
    {
        services.AddHostedService<SchedulerHostedService>();

        return services;
    }
}
