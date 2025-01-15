using MasjidOnline.Data.Interface.Captcha;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Data.Interface.Log;
using MasjidOnline.Data.Interface.Transactions;
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
