using System.Diagnostics;
using MasjidOnline.Data.IdGenerator;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddSingleton<IAuditIdGenerator, AuditIdGenerator>();
        services.AddSingleton<ICoreIdGenerator, CoreIdGenerator>();
        services.AddSingleton<ICaptchaIdGenerator, CaptchaIdGenerator>();
        services.AddSingleton<IEventIdGenerator, EventIdGenerator>();
        services.AddSingleton<IInfaqsIdGenerator, InfaqsIdGenerator>();
        services.AddSingleton<ISessionsIdGenerator, SessionsIdGenerator>();
        services.AddSingleton<IUsersIdGenerator, UsersIdGenerator>();

        if (Debugger.IsAttached)
            services.AddScoped<IDataTransaction, SharedDataTransaction>();
        else
            services.AddScoped<IDataTransaction, DataTransaction>();

        return services;
    }
}
