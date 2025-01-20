using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.SqLite.DataContext;
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
        services.AddDbContextPool<CaptchaDataContext, SqLiteCaptchaDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Captcha");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);


        services.AddDbContextPool<CoreDataContext, SqLiteCoreDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Core");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);


        services.AddDbContextPool<EventDataContext, SqLiteEventDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Event");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);


        services.AddDbContextPool<TransactionDataContext, SqLiteTransactionDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Transaction");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);


        services.AddDbContextPool<UserDataContext, SqLiteUserDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("User");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);


        services.AddTransient<ICaptchaInitializer, SqLiteCaptchaInitializer>();
        services.AddTransient<ICoreInitializer, SqLiteCoreInitializer>();
        services.AddTransient<IEventInitializer, SqLiteEventInitializer>();
        services.AddTransient<ITransactionInitializer, SqLiteTransactionInitializer>();
        services.AddTransient<IUserInitializer, SqLiteUserInitializer>();

        services.AddTransient<ICaptchaDefinition, SqLiteDefinition<SqLiteCaptchaDataContext>>();
        services.AddTransient<ICoreDefinition, SqLiteDefinition<SqLiteCoreDataContext>>();
        services.AddTransient<IEventDefinition, SqLiteDefinition<SqLiteEventDataContext>>();
        services.AddTransient<ITransactionDefinition, SqLiteDefinition<SqLiteTransactionDataContext>>();
        services.AddTransient<IUserDefinition, SqLiteDefinition<SqLiteUserDataContext>>();

        return services;
    }
}
