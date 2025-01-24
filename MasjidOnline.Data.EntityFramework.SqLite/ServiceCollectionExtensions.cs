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
    public static IServiceCollection AddSqLiteEntityFrameworkData(this IServiceCollection services, IConfigurationManager configurationManager)
    {
        services.AddDbContextPool<AuditDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Audit");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);


        services.AddDbContextPool<CaptchaDataContext, CaptchaDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Captcha");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);


        services.AddDbContextPool<CoreDataContext, CoreDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Core");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);


        services.AddDbContextPool<EventDataContext, EventDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Event");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);


        services.AddDbContextPool<TransactionDataContext, TransactionDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Transaction");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);


        services.AddDbContextPool<UserDataContext, UserDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("User");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);


        services.AddTransient<IAuditInitializer, SqLiteAuditInitializer>();
        services.AddTransient<ICaptchaInitializer, SqLiteCaptchaInitializer>();
        services.AddTransient<ICoreInitializer, SqLiteCoreInitializer>();
        services.AddTransient<IEventInitializer, SqLiteEventInitializer>();
        services.AddTransient<ITransactionInitializer, SqLiteTransactionInitializer>();
        services.AddTransient<IUserInitializer, SqLiteUserInitializer>();

        services.AddTransient<IAuditDefinition, SqLiteDefinition<AuditDataContext>>();
        services.AddTransient<ICaptchaDefinition, SqLiteDefinition<CaptchaDataContext>>();
        services.AddTransient<ICoreDefinition, SqLiteDefinition<CoreDataContext>>();
        services.AddTransient<IEventDefinition, SqLiteDefinition<EventDataContext>>();
        services.AddTransient<ITransactionDefinition, SqLiteDefinition<TransactionDataContext>>();
        services.AddTransient<IUserDefinition, SqLiteDefinition<UserDataContext>>();

        return services;
    }
}
