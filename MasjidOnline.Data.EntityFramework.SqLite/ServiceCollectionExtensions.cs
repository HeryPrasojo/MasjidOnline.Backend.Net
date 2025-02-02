using System;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.SqLite.Initializer;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqLiteEntityFrameworkData(this IServiceCollection services, IConfiguration configurationManager)
    {
        var option = configurationManager.Get<Option>() ?? throw new ApplicationException($"Get {nameof(Option)} fail");

        services.AddDbContextPool<AuditDataContext>(b => b.UseSqlite(option.ConnectionStrings.Audit), poolSize: 2);
        services.AddDbContextPool<CaptchaDataContext, CaptchaDataContext>(b => b.UseSqlite(option.ConnectionStrings.Captcha), poolSize: 2);
        services.AddDbContextPool<CoreDataContext, CoreDataContext>(b => b.UseSqlite(option.ConnectionStrings.Core), poolSize: 2);
        services.AddDbContextPool<EventDataContext, EventDataContext>(b => b.UseSqlite(option.ConnectionStrings.Event), poolSize: 2);
        services.AddDbContextPool<SessionsDataContext, SessionsDataContext>(b => b.UseSqlite(option.ConnectionStrings.Sessions), poolSize: 2);
        services.AddDbContextPool<TransactionsDataContext, TransactionsDataContext>(b => b.UseSqlite(option.ConnectionStrings.Transactions), poolSize: 2);
        services.AddDbContextPool<UsersDataContext, UsersDataContext>(b => b.UseSqlite(option.ConnectionStrings.Users), poolSize: 2);

        services.AddTransient<IAuditInitializer, SqLiteAuditInitializer>();
        services.AddTransient<ICaptchaInitializer, SqLiteCaptchaInitializer>();
        services.AddTransient<ICoreInitializer, SqLiteCoreInitializer>();
        services.AddTransient<IEventInitializer, SqLiteEventInitializer>();
        services.AddTransient<ISessionsInitializer, SqLiteSessionsInitializer>();
        services.AddTransient<ITransactionsInitializer, SqLiteTransactionsInitializer>();
        services.AddTransient<IUsersInitializer, SqLiteUserInitializer>();

        services.AddTransient<IAuditDefinition, SqLiteDefinition<AuditDataContext>>();
        services.AddTransient<ICaptchaDefinition, SqLiteDefinition<CaptchaDataContext>>();
        services.AddTransient<ICoreDefinition, SqLiteDefinition<CoreDataContext>>();
        services.AddTransient<IEventDefinition, SqLiteDefinition<EventDataContext>>();
        services.AddTransient<ISessionsDefinition, SqLiteDefinition<SessionsDataContext>>();
        services.AddTransient<ITransactionsDefinition, SqLiteDefinition<TransactionsDataContext>>();
        services.AddTransient<IUsersDefinition, SqLiteDefinition<UsersDataContext>>();

        return services;
    }
}
