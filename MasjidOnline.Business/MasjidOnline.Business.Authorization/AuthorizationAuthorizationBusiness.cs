using MasjidOnline.Business.Authorization.Authorization;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Authorization.Interface.Authorization;

namespace MasjidOnline.Business.Authorization;

public class AuthorizationAuthorizationBusiness : IAuthorizationAuthorizationBusiness
{
    public IUserInternalPermissionAuthorization UserInternalPermission { get; } = new UserInternalPermissionAuthorization();
}
