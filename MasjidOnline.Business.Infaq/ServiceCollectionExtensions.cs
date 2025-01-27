using MasjidOnline.Business.Infaq.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Infaq;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDonationBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IAnonymInfaqBusiness, AnonymInfaqBusiness>();

        return services;
    }
}
