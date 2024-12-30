using MasjidOnline.Data.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityIdGenerator(this IServiceCollection services)
    {
        services.AddSingleton<IEntityIdGenerator, EntityIdGenerator>();

        return services;
    }
}
