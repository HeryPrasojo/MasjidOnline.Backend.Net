using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Business.User.User;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

public class UserUserBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    Service.Interface.IService _service
    ) : IUserUserBusiness
{
    public IRegisterBusiness Register { get; } = new RegisterBusiness(_optionsMonitor, _authorizationBusiness, _service);
    public ILoginBusiness Login { get; } = new LoginBusiness(_authorizationBusiness, _service);
    public ILogoutBusiness Logout { get; } = new LogoutBusiness();
    public IVerifySetPasswordBusiness VerifySetPassword { get; } = new VerifySetPasswordBusiness(_service);
}
