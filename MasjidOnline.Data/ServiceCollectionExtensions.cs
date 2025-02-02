using MasjidOnline.Data.IdGenerator;
using MasjidOnline.Data.Interface.IdGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityIdGenerator(this IServiceCollection services)
    {
        services.AddSingleton<IAuditIdGenerator, AuditIdGenerator>();
        services.AddSingleton<ICoreIdGenerator, CoreIdGenerator>();
        services.AddSingleton<ICaptchaIdGenerator, CaptchaIdGenerator>();
        services.AddSingleton<IEventIdGenerator, EventIdGenerator>();
        services.AddSingleton<ISessionsIdGenerator, SessionIdGenerator>();
        services.AddSingleton<ITransactionsIdGenerator, TransactionIdGenerator>();
        services.AddSingleton<IUsersIdGenerator, UserIdGenerator>();

        return services;
    }
}
