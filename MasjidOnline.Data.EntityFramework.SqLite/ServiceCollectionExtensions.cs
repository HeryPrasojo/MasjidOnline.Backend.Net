using MasjidOnline.Data.EntityFramework.SqLite.Captcha;
using MasjidOnline.Data.EntityFramework.SqLite.Core;
using MasjidOnline.Data.EntityFramework.SqLite.Log;
using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Data.Interface.Log;
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

        services.AddScoped<ICoreData, SqLiteCoreData>();
        services.AddScoped<ICoreDefinition, SqLiteCoreDefinition>();
        services.AddScoped<ICoreInitializer, SqLiteCoreInitializer>();


        services.AddDbContextPool<CaptchaDataContext, SqLiteCaptchaDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Captcha");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);

        services.AddScoped<ICaptchaData, SqLiteCaptchaData>();
        services.AddScoped<ICaptchaDefinition, SqLiteCaptchaDefinition>();
        services.AddScoped<ICaptchaInitializer, SqLiteCaptchaInitializer>();


        services.AddDbContextPool<LogDataContext, SqLiteLogDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("Log");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);

        services.AddScoped<ILogData, SqLiteLogData>();
        services.AddScoped<ILogDefinition, SqLiteLogDefinition>();
        services.AddScoped<ILogInitializer, SqLiteLogInitializer>();

        return services;
    }
}
