using MasjidOnline.Business.User.Interface.User;

namespace MasjidOnline.Business.User.Interface;

public interface IUserUserBusiness
{
    IRegisterEmailBusiness RegisterEmail { get; }
    ILoginEmailBusiness LoginEmail { get; }
    ISetPasswordBusiness SetPassword { get; }
    ILogoutBusiness Logout { get; }
}
