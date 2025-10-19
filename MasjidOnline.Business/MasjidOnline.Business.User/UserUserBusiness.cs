using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Business.User.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User;

public class UserUserBusiness(
    //IOptionsMonitor<BusinessOptions> _optionsMonitor,
    //Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    IIdGenerator _idGenerator,
    ISessionAuthenticationBusiness _sessionAuthenticationBusiness,
    Service.Interface.IService _service
    ) : IUserUserBusiness
{
    public IAddRegisterBusiness AddRegister { get; } = new AddRegisterBusiness();
    public ILoginEmailBusiness LoginEmail { get; } = new LoginEmailBusiness(_sessionAuthenticationBusiness, _service);
    public ILogoutBusiness Logout { get; } = new LogoutBusiness();
    public ISetPasswordBusiness SetPassword { get; } = new SetPasswordBusiness(_idGenerator, _service);
}
