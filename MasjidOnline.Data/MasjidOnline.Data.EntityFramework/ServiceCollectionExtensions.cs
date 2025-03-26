using MasjidOnline.Data.EntityFramework.Databases;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Databases;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.EntityFramework;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkData(this IServiceCollection services)
    {
        services.AddScoped<IAuditDatabase, AuditDatabase>();
        services.AddScoped<ICaptchaDatabase, CaptchaDatabase>();
        services.AddScoped<IPersonDatabase, PersonDatabase>();
        services.AddScoped<IEventDatabase, EventDatabase>();
        services.AddScoped<IInfaqDatabase, InfaqDatabase>();
        services.AddScoped<ISessionDatabase, SessionDatabase>();
        services.AddScoped<IUserDatabase, UserDatabase>();

        services.AddScoped<IData, EntityFrameworkData>();

        return services;
    }
}
