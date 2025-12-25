using MasjidOnline.Business.User.Interface.User;

namespace MasjidOnline.Business.User.Interface;

public interface IUserUserBusiness
{
    IRegisterBusiness Register { get; }
    ILoginBusiness Login { get; }
    ISetPasswordBusiness SetPassword { get; }
    ILogoutBusiness Logout { get; }
}
