using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Authorization.Interface.User;
using MasjidOnline.Business.Authorization.User;

namespace MasjidOnline.Business.Authorization;

internal class UserAuthorizationBusiness : IUserAuthorizationBusiness
{
    public IInternalAuthorization Internal { get; } = new InternalAuthorization();
}
