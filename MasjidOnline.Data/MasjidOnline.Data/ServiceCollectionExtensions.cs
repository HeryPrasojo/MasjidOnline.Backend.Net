using MasjidOnline.Data.IdGenerators;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddSingleton<IIdGenerator, IdGenerator>();

        services.AddSingleton<IAuditIdGenerator, AuditIdGenerator>();
        services.AddSingleton<IPersonIdGenerator, PersonIdGenerator>();
        services.AddSingleton<ICaptchaIdGenerator, CaptchaIdGenerator>();
        services.AddSingleton<IEventIdGenerator, EventIdGenerator>();
        services.AddSingleton<IInfaqIdGenerator, InfaqIdGenerator>();
        services.AddSingleton<ISessionIdGenerator, SessionIdGenerator>();
        services.AddSingleton<IUserIdGenerator, UserIdGenerator>();


        services.AddScoped<IDataTransaction, DataTransaction>();

        return services;
    }
}
