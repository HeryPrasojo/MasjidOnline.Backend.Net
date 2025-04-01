using MasjidOnline.Business.User.Interface.User;

namespace MasjidOnline.Business.User.Interface;

public interface IUserUserBusiness
{
    IAddRegisterBusiness AddRegister { get; }
    ILoginBusiness Login { get; }
    ISetPasswordBusiness SetPassword { get; }
}
