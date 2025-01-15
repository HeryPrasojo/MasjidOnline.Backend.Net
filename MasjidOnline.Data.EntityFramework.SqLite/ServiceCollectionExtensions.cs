using MasjidOnline.Data.EntityFramework.SqLite.Captcha;
using MasjidOnline.Data.EntityFramework.SqLite.Core;
using MasjidOnline.Data.EntityFramework.SqLite.Log;
using MasjidOnline.Data.EntityFramework.SqLite.Transaction;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Data.Interface.Log;
using MasjidOnline.Data.Interface.Transactions;
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
