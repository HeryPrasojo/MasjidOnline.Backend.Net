using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.Infaq;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfaqBusiness(this IServiceCollection services)
    {
        services.AddSingleton<Business.Infaq.Interface.Expire.IAddBusiness, Business.Infaq.Expire.AddBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Expire.IApproveBusiness, Business.Infaq.Expire.ApproveBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Expire.ICancelBusiness, Business.Infaq.Expire.CancelBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Expire.IGetManyBusiness, Business.Infaq.Expire.GetManyBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Expire.IGetManyNewBusiness, Business.Infaq.Expire.GetManyNewBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Expire.IGetOneBusiness, Business.Infaq.Expire.GetOneBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Expire.IGetOneNewBusiness, Business.Infaq.Expire.GetOneNewBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Expire.IRejectBusiness, Business.Infaq.Expire.RejectBusiness>();

        services.AddSingleton<Business.Infaq.Interface.Infaq.IAddAnonymBusiness, Business.Infaq.Infaq.AddAnonymBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Infaq.IGetManyBusiness, Business.Infaq.Infaq.GetManyBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Infaq.IGetManyDueBusiness, Business.Infaq.Infaq.GetManyDueBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Infaq.IGetOneBusiness, Business.Infaq.Infaq.GetOneBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Infaq.IGetOneDueBusiness, Business.Infaq.Infaq.GetOneDueBusiness>();

        services.AddSingleton<Business.Infaq.Interface.Success.IAddBusiness, Business.Infaq.Success.AddBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Success.IApproveBusiness, Business.Infaq.Success.ApproveBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Success.ICancelBusiness, Business.Infaq.Success.CancelBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Success.IGetManyBusiness, Business.Infaq.Success.GetManyBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Success.IGetManyNewBusiness, Business.Infaq.Success.GetManyNewBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Success.IGetOneBusiness, Business.Infaq.Success.GetOneBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Success.IGetOneNewBusiness, Business.Infaq.Success.GetOneNewBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Success.IRejectBusiness, Business.Infaq.Success.RejectBusiness>();

        services.AddSingleton<Business.Infaq.Interface.Void.IAddBusiness, Business.Infaq.Void.AddBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Void.IApproveBusiness, Business.Infaq.Void.ApproveBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Void.ICancelBusiness, Business.Infaq.Void.CancelBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Void.IGetManyBusiness, Business.Infaq.Void.GetManyBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Void.IGetManyNewBusiness, Business.Infaq.Void.GetManyNewBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Void.IGetOneBusiness, Business.Infaq.Void.GetOneBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Void.IGetOneNewBusiness, Business.Infaq.Void.GetOneNewBusiness>();
        services.AddSingleton<Business.Infaq.Interface.Void.IRejectBusiness, Business.Infaq.Void.RejectBusiness>();

        return services;
    }
}
