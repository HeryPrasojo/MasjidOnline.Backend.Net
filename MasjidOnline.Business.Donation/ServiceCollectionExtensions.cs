using MasjidOnline.Business.Donation.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Donation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDonationBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IDonateBusiness, DonateBusiness>();

        return services;
    }
}
