using MasjidOnline.Business.User.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.User;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserBusiness(this IServiceCollection services)
    {
        services.AddSingleton<IInitializerBusiness, InitializerBusiness>();

        services.AddSingleton<Business.User.Interface.Internal.IAddBusiness, Business.User.Internal.AddBusiness>();
        services.AddSingleton<Business.User.Interface.Internal.IApproveBusiness, Business.User.Internal.ApproveBusiness>();
        services.AddSingleton<Business.User.Interface.Internal.ICancelBusiness, Business.User.Internal.CancelBusiness>();
        services.AddSingleton<Business.User.Interface.Internal.IGetManyBusiness, Business.User.Internal.GetManyBusiness>();
        services.AddSingleton<Business.User.Interface.Internal.IGetManyNewBusiness, Business.User.Internal.GetManyNewBusiness>();
        services.AddSingleton<Business.User.Interface.Internal.IGetOneBusiness, Business.User.Internal.GetOneBusiness>();
        services.AddSingleton<Business.User.Interface.Internal.IGetOneNewBusiness, Business.User.Internal.GetOneNewBusiness>();
        services.AddSingleton<Business.User.Interface.Internal.IRejectBusiness, Business.User.Internal.RejectBusiness>();

        services.AddSingleton<Business.User.Interface.User.IAddRegisterBusiness, Business.User.User.AddRegisterBusiness>();
        services.AddSingleton<Business.User.Interface.User.ILoginBusiness, Business.User.User.LoginBusiness>();
        services.AddSingleton<Business.User.Interface.User.ISetPasswordBusiness, Business.User.User.SetPasswordBusiness>();

        return services;
    }
}
