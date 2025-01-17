using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.SqLite.DataContext;
using MasjidOnline.Data.EntityFramework.SqLite.Definition;
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
        services.AddDbContextPool<CoreDataContext, SqLiteCoreDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Core");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);

        services.AddTransient<ICoreDefinition, SqLiteCoreDefinition>();
        services.AddTransient<ICoreInitializer, SqLiteCoreInitializer>();


        services.AddDbContextPool<CaptchaDataContext, SqLiteCaptchaDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Captcha");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);

        services.AddTransient<ICaptchaDefinition, SqLiteCaptchaDefinition>();
        services.AddTransient<ICaptchaInitializer, SqLiteCaptchaInitializer>();


        services.AddDbContextPool<TransactionDataContext, SqLiteTransactionDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Transaction");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);

        services.AddTransient<ITransactionDefinition, SqLiteTransactionDefinition>();
        services.AddTransient<ITransactionInitializer, SqLiteTransactionInitializer>();


        services.AddDbContextPool<LogDataContext, SqLiteLogDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Log");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);

        services.AddTransient<ILogDefinition, SqLiteLogDefinition>();
        services.AddTransient<ILogInitializer, SqLiteLogInitializer>();

        return services;
    }
}
