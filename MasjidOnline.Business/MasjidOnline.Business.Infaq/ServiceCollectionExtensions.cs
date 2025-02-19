using MasjidOnline.Business.Infaq.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Infaq;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfaqBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IAnonymInfaqBusiness, AnonymInfaqBusiness>();
        services.AddSingleton<ITabularBusiness, TabularBusiness>();

        return services;
    }
}
