using MasjidOnline.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqLiteEntityFrameworkDataAccess(this IServiceCollection services, IConfigurationManager configurationManager)
    {
        services.AddDbContextPool<SqLiteDataContext>(b =>
            {
                var connectionString = configurationManager.GetConnectionString("ConnectionString");

                b.UseSqlite(connectionString);
            },
            poolSize: 2);

        services.AddScoped<DataContext, SqLiteDataContext>();

        services.AddScoped<IDataAccess, SqLiteDataAccess>();

        return services;
    }
}
