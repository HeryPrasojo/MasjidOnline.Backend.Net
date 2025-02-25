using MasjidOnline.Business.Infaq.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Infaq;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfaqBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IInfaqAddByAnonymBusiness, InfaqAddByAnonymBusiness>();
        services.AddSingleton<IInfaqGetManyBusiness, InfaqGetManyBusiness>();

        return services;
    }
}
