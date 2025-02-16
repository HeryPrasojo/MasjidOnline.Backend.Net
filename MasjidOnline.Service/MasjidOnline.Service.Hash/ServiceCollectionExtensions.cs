using MasjidOnline.Service.Hash.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service.Hash;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHashService(this IServiceCollection services)
    {
        services.AddSingleton<IHash128Service, Hash128Service>();
        services.AddSingleton<IHash512Service, Hash512Service>();

        return services;
    }
}
