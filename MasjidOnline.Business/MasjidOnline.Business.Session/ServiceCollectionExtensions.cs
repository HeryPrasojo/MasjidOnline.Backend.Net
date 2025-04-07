using MasjidOnline.Business.Session.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Session;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSessionBusiness(this IServiceCollection services)
    {
        services.AddScoped<Interface.Session>();

        services.AddSingleton<ISessionBusiness, SessionBusiness>();

        return services;
    }
}
