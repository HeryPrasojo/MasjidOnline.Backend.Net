using MasjidOnline.Business.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IBusiness, Business>();

        return services;
    }
}
