using System;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.SqLite.Initializer;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Data.Interface.ViewModel.Option;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqLiteEntityFrameworkData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStrings = configuration.GetSection("ConnectionStrings")
            .Get<ConnectionStrings>() ?? throw new ApplicationException($"Get {nameof(ConnectionStrings)} fail");

        services.AddDbContextPool<AuditDataContext>(b => b.UseSqlite(connectionStrings.Audit), poolSize: 2);
        services.AddDbContextPool<CaptchaDataContext>(b => b.UseSqlite(connectionStrings.Captcha), poolSize: 2);
        services.AddDbContextPool<EventDataContext>(b => b.UseSqlite(connectionStrings.Event), poolSize: 2);
        services.AddDbContextPool<InfaqDataContext>(b => b.UseSqlite(connectionStrings.Infaq), poolSize: 2);
        services.AddDbContextPool<PersonDataContext>(b => b.UseSqlite(connectionStrings.Person), poolSize: 2);
        services.AddDbContextPool<SessionDataContext>(b => b.UseSqlite(connectionStrings.Session), poolSize: 2);
        services.AddDbContextPool<UserDataContext>(b => b.UseSqlite(connectionStrings.User), poolSize: 2);

        services.AddTransient<IAuditInitializer, SqLiteAuditInitializer>();
        services.AddTransient<ICaptchaInitializer, SqLiteCaptchaInitializer>();
        services.AddTransient<IPersonInitializer, SqLitePersonInitializer>();
        services.AddTransient<IEventInitializer, SqLiteEventInitializer>();
        services.AddTransient<IInfaqInitializer, SqLiteInfaqInitializer>();
        services.AddTransient<ISessionInitializer, SqLiteSessionInitializer>();
        services.AddTransient<IUserInitializer, SqLiteUserInitializer>();

        services.AddTransient<IAuditDefinition, SqLiteDefinition<AuditDataContext>>();
        services.AddTransient<ICaptchaDefinition, SqLiteDefinition<CaptchaDataContext>>();
        services.AddTransient<IPersonDefinition, SqLiteDefinition<PersonDataContext>>();
        services.AddTransient<IEventDefinition, SqLiteDefinition<EventDataContext>>();
        services.AddTransient<IInfaqsDefinition, SqLiteDefinition<InfaqDataContext>>();
        services.AddTransient<ISessionsDefinition, SqLiteDefinition<SessionDataContext>>();
        services.AddTransient<IUsersDefinition, SqLiteDefinition<UserDataContext>>();

        return services;
    }
}
