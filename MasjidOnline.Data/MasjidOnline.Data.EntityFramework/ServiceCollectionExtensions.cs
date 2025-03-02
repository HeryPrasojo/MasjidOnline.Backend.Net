using MasjidOnline.Data.EntityFramework.Datas;
using MasjidOnline.Data.Interface.Datas;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.EntityFramework;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkData(this IServiceCollection services)
    {
        services.AddScoped<IAuditData, AuditData>();
        services.AddScoped<ICaptchaData, CaptchaData>();
        services.AddScoped<ICoreData, CoreData>();
        services.AddScoped<IEventData, EventData>();
        services.AddScoped<IInfaqData, InfaqData>();
        services.AddScoped<ISessionData, SessionData>();
        services.AddScoped<IUserData, UserData>();

        return services;
    }
}
