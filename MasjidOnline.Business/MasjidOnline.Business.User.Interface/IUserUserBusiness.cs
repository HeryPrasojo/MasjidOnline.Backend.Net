using MasjidOnline.Business.User.Interface.User;

namespace MasjidOnline.Business.User.Interface;

public interface IUserUserBusiness
{
    IAddRegisterBusiness AddRegister { get; }
    ILoginEmailBusiness LoginEmail { get; }
    ISetPasswordBusiness SetPassword { get; }
}
