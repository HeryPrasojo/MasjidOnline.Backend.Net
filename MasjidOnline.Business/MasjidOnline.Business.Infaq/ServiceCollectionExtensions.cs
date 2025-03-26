using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Infaq;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfaqBusiness(this IServiceCollection services)
    {
        services.AddSingleton<Interface.Expire.IAddBusiness, Expire.AddBusiness>();
        services.AddSingleton<Interface.Expire.IApproveBusiness, Expire.ApproveBusiness>();
        services.AddSingleton<Interface.Expire.ICancelBusiness, Expire.CancelBusiness>();
        services.AddSingleton<Interface.Expire.IGetManyBusiness, Expire.GetManyBusiness>();
        services.AddSingleton<Interface.Expire.IGetManyNewBusiness, Expire.GetManyNewBusiness>();
        services.AddSingleton<Interface.Expire.IGetOneBusiness, Expire.GetOneBusiness>();
        services.AddSingleton<Interface.Expire.IGetOneNewBusiness, Expire.GetOneNewBusiness>();
        services.AddSingleton<Interface.Expire.IRejectBusiness, Expire.RejectBusiness>();

        services.AddSingleton<Interface.Infaq.IAddAnonymBusiness, Infaq.AddAnonymBusiness>();
        services.AddSingleton<Interface.Infaq.IGetManyBusiness, Infaq.GetManyBusiness>();
        services.AddSingleton<Interface.Infaq.IGetManyDueBusiness, Infaq.GetManyDueBusiness>();
        services.AddSingleton<Interface.Infaq.IGetOneBusiness, Infaq.GetOneBusiness>();
        services.AddSingleton<Interface.Infaq.IGetOneDueBusiness, Infaq.GetOneDueBusiness>();

        services.AddSingleton<Interface.Success.IAddBusiness, Success.AddBusiness>();
        services.AddSingleton<Interface.Success.IApproveBusiness, Success.ApproveBusiness>();
        services.AddSingleton<Interface.Success.ICancelBusiness, Success.CancelBusiness>();
        services.AddSingleton<Interface.Success.IGetManyBusiness, Success.GetManyBusiness>();
        services.AddSingleton<Interface.Success.IGetManyNewBusiness, Success.GetManyNewBusiness>();
        services.AddSingleton<Interface.Success.IGetOneBusiness, Success.GetOneBusiness>();
        services.AddSingleton<Interface.Success.IGetOneNewBusiness, Success.GetOneNewBusiness>();
        services.AddSingleton<Interface.Success.IRejectBusiness, Success.RejectBusiness>();

        services.AddSingleton<Interface.Void.IAddBusiness, Void.AddBusiness>();
        services.AddSingleton<Interface.Void.IApproveBusiness, Void.ApproveBusiness>();
        services.AddSingleton<Interface.Void.ICancelBusiness, Void.CancelBusiness>();
        services.AddSingleton<Interface.Void.IGetManyBusiness, Void.GetManyBusiness>();
        services.AddSingleton<Interface.Void.IGetManyNewBusiness, Void.GetManyNewBusiness>();
        services.AddSingleton<Interface.Void.IGetOneBusiness, Void.GetOneBusiness>();
        services.AddSingleton<Interface.Void.IGetOneNewBusiness, Void.GetOneNewBusiness>();
        services.AddSingleton<Interface.Void.IRejectBusiness, Void.RejectBusiness>();

        return services;
    }
}
