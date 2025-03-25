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
        services.AddScoped<IData, CaptchaDatabase>();
        services.AddScoped<IPersonDatabase, PersonDatabase>();
        services.AddScoped<IEventDatabase, EventDatabase>();
        services.AddScoped<IData, InfaqDatabase>();
        services.AddScoped<IData, SessionDatabase>();
        services.AddScoped<IData, UserDatabase>();

        services.AddScoped<IData, EntityFrameworkData>();

        return services;
    }
}
