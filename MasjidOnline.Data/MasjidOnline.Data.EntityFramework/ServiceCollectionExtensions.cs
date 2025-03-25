using MasjidOnline.Data.EntityFramework.Datas;
using MasjidOnline.Data.Interface.Datas;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.EntityFramework;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkData(this IServiceCollection services)
    {
        services.AddScoped<IAuditDatabase, AuditData>();
        services.AddScoped<ICaptchaDatabase, CaptchaData>();
        services.AddScoped<IPersonDatabase, PersonData>();
        services.AddScoped<IEventDatabase, EventData>();
        services.AddScoped<IInfaqDatabase, InfaqData>();
        services.AddScoped<ISessionDatabase, SessionData>();
        services.AddScoped<IUserDatabase, UserData>();

        return services;
    }
}
