using MasjidOnline.Data.EntityFramework.Datas;
using MasjidOnline.Data.Interface.Datas;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.EntityFramework;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddScoped<ICoreData, CoreData>();
        services.AddScoped<ICaptchaData, CaptchaData>();
        services.AddScoped<ITransactionData, TransactionData>();
        services.AddScoped<ILogData, LogData>();

        return services;
    }
}
