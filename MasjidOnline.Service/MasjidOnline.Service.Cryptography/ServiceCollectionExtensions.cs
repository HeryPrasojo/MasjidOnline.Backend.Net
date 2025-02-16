using MasjidOnline.Service.Cryptography.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service.Cryptography;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEncryptionService(this IServiceCollection services)
    {
        services.AddSingleton<IEncryption128128, Encryption128128>();

        return services;
    }
}
