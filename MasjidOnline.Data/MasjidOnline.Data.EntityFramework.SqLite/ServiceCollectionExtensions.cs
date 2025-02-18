using System;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.SqLite.Initializer;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Data.Interface.Model.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqLiteEntityFrameworkData(this IServiceCollection services, IConfiguration configurationManager)
    {
        var option = configurationManager.Get<ConnectionStrings>() ?? throw new ApplicationException($"Get {nameof(ConnectionStrings)} fail");

        services.AddDbContextPool<AuditDataContext>(b => b.UseSqlite(option.Audit), poolSize: 2);
        services.AddDbContextPool<CaptchaDataContext>(b => b.UseSqlite(option.Captcha), poolSize: 2);
        services.AddDbContextPool<CoreDataContext>(b => b.UseSqlite(option.Core), poolSize: 2);
        services.AddDbContextPool<EventDataContext>(b => b.UseSqlite(option.Event), poolSize: 2);
        services.AddDbContextPool<InfaqsDataContext>(b => b.UseSqlite(option.Infaqs), poolSize: 2);
        services.AddDbContextPool<SessionsDataContext>(b => b.UseSqlite(option.Sessions), poolSize: 2);
        services.AddDbContextPool<UsersDataContext>(b => b.UseSqlite(option.Users), poolSize: 2);

        services.AddTransient<IAuditInitializer, SqLiteAuditInitializer>();
        services.AddTransient<ICaptchaInitializer, SqLiteCaptchaInitializer>();
        services.AddTransient<ICoreInitializer, SqLiteCoreInitializer>();
        services.AddTransient<IEventInitializer, SqLiteEventInitializer>();
        services.AddTransient<IInfaqsInitializer, SqLiteInfaqsInitializer>();
        services.AddTransient<ISessionsInitializer, SqLiteSessionsInitializer>();
        services.AddTransient<IUsersInitializer, SqLiteUsersInitializer>();

        services.AddTransient<IAuditDefinition, SqLiteDefinition<AuditDataContext>>();
        services.AddTransient<ICaptchaDefinition, SqLiteDefinition<CaptchaDataContext>>();
        services.AddTransient<ICoreDefinition, SqLiteDefinition<CoreDataContext>>();
        services.AddTransient<IEventDefinition, SqLiteDefinition<EventDataContext>>();
        services.AddTransient<IInfaqsDefinition, SqLiteDefinition<InfaqsDataContext>>();
        services.AddTransient<ISessionsDefinition, SqLiteDefinition<SessionsDataContext>>();
        services.AddTransient<IUsersDefinition, SqLiteDefinition<UsersDataContext>>();

        return services;
    }
}
