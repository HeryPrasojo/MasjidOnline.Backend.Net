using MasjidOnline.Business.Transaction.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Transaction;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTransactionBusiness(this IServiceCollection services)
    {
        services.AddSingleton<ITabularBusiness, TabularBusiness>();

        return services;
    }
}
