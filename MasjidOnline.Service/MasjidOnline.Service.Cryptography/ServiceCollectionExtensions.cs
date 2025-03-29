using MasjidOnline.Service.Cryptography.Interface;
using MasjidOnline.Service.Cryptography.Interface.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Service.Cryptography;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCryptographyService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CryptographyOptions>(configuration.GetSection("Cryptography"));

        services.AddSingleton<IEncryption128128, Encryption128128>();

        return services;
    }
}
