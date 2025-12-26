using MasjidOnline.Business.User.Interface.User;

namespace MasjidOnline.Business.User.Interface;

public interface IUserUserBusiness
{
    IRegisterBusiness Register { get; }
    ILoginBusiness Login { get; }
    IVerifySetPasswordBusiness VerifySetPassword { get; }
    ILogoutBusiness Logout { get; }
}
