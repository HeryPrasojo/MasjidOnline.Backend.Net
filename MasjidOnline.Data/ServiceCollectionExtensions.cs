using MasjidOnline.Data.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityIdGenerator(this IServiceCollection services)
    {
        services.AddSingleton<ICoreEntityIdGenerator, CoreEntityIdGenerator>();
        services.AddSingleton<ILogEntityIdGenerator, LogEntityIdGenerator>();

        return services;
    }
}
