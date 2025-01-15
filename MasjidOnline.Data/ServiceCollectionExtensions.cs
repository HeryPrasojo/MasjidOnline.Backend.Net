using MasjidOnline.Data.IdGenerator;
using MasjidOnline.Data.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityIdGenerator(this IServiceCollection services)
    {
        services.AddSingleton<ICoreIdGenerator, CoreIdGenerator>();
        services.AddSingleton<ICaptchaIdGenerator, CaptchaIdGenerator>();
        services.AddSingleton<ILogIdGenerator, LogIdGenerator>();
        services.AddSingleton<ITransactionIdGenerator, TransactionIdGenerator>();

        return services;
    }
}
