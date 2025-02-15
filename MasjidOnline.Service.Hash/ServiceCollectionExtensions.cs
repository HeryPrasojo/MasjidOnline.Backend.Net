using MasjidOnline.Service.Hash.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service.Hash;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHash512Service(this IServiceCollection services)
    {
        services.AddSingleton<IHash512Service, Hash512Service>();

        return services;
    }
}
