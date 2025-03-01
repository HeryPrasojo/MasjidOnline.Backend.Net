using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Infaq;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfaqBusiness(this IServiceCollection services)
    {
        services.AddSingleton<Business.Infaq.Interface.Infaq.IAddAnonymBusiness, Business.Infaq.Infaq.InfaqAddAnonymBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Infaq.IGetManyBusiness, Business.Infaq.Infaq.InfaqGetManyBusiness>();

        return services;
    }
}
