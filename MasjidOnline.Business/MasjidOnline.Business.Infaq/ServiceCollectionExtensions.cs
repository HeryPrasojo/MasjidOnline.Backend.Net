using MasjidOnline.Business.Infaq.Infaq;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Infaq;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfaqBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IAddAnonymBusiness, InfaqAddAnonymBusiness>();
        services.AddSingleton<IGetManyBusiness, InfaqGetManyBusiness>();

        return services;
    }
}
