using System;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface;
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

        // todo low UseQueryTrackingBehavior
        services.AddDbContextPool<AccountancyDataContext>(
            b => b.UseSqlite(connectionStrings.Accountancy)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
            poolSize: 2);
        services.AddDbContextPool<AuditDataContext>(b => b.UseSqlite(connectionStrings.Audit), poolSize: 2);
        services.AddDbContextPool<AuthorizationDataContext>(b => b.UseSqlite(connectionStrings.Authorization), poolSize: 2);
        services.AddDbContextPool<CaptchaDataContext>(b => b.UseSqlite(connectionStrings.Captcha), poolSize: 2);
        services.AddDbContextPool<DatabaseTemplateDataContext>(b => b.UseSqlite(connectionStrings.DatabaseTemplate), poolSize: 2);
        services.AddDbContextPool<EventDataContext>(b => b.UseSqlite(connectionStrings.Event), poolSize: 2);
        services.AddDbContextPool<InfaqDataContext>(b => b.UseSqlite(connectionStrings.Infaq), poolSize: 2);
        services.AddDbContextPool<PaymentDataContext>(b => b.UseSqlite(connectionStrings.Payment), poolSize: 2);
        services.AddDbContextPool<PersonDataContext>(b => b.UseSqlite(connectionStrings.Person), poolSize: 2);
        services.AddDbContextPool<SessionDataContext>(b => b.UseSqlite(connectionStrings.Session), poolSize: 2);
        services.AddDbContextPool<UserDataContext>(b => b.UseSqlite(connectionStrings.User), poolSize: 2);

        services.AddScoped<IDataInitializer, DataInitializer>();

        return services;
    }
}
