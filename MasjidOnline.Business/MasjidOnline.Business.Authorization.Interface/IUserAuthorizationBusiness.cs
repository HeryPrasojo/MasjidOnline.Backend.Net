using MasjidOnline.Business.Authorization.Interface.User;

namespace MasjidOnline.Business.Authorization.Interface;

public interface IUserAuthorizationBusiness
{
    IInternalAuthorization Internal { get; }
}
