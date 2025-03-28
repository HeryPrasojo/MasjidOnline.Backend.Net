using MasjidOnline.Business.User.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Business.User;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserBusiness(this IServiceCollection services)
    {
        services.AddTransient<IInitializerBusiness, InitializerBusiness>();

        services.AddSingleton<Interface.Internal.IAddBusiness, Internal.AddBusiness>();
        services.AddSingleton<Interface.Internal.IApproveBusiness, Internal.ApproveBusiness>();
        services.AddSingleton<Interface.Internal.ICancelBusiness, Internal.CancelBusiness>();
        services.AddSingleton<Interface.Internal.IGetManyBusiness, Internal.GetManyBusiness>();
        services.AddSingleton<Interface.Internal.IGetManyNewBusiness, Internal.GetManyNewBusiness>();
        services.AddSingleton<Interface.Internal.IGetOneBusiness, Internal.GetOneBusiness>();
        services.AddSingleton<Interface.Internal.IGetOneNewBusiness, Internal.GetOneNewBusiness>();
        services.AddSingleton<Interface.Internal.IRejectBusiness, Internal.RejectBusiness>();

        services.AddSingleton<Interface.User.IAddRegisterBusiness, User.AddRegisterBusiness>();
        services.AddSingleton<Interface.User.ILoginBusiness, User.LoginBusiness>();
        services.AddSingleton<Interface.User.ISetPasswordBusiness, User.SetPasswordBusiness>();

        return services;
    }
}
