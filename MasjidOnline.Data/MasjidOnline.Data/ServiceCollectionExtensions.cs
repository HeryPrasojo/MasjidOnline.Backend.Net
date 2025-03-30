using MasjidOnline.Data.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddSingleton<IIdGenerator, IdGenerator>();

        services.AddScoped<IDataTransaction, DataTransaction>();

        return services;
    }
}
