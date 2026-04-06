using MasjidOnline.Business.Authorization.Interface.Authorization;

namespace MasjidOnline.Business.Authorization.Interface;

public interface IAuthorizationAuthorizationBusiness
{
    IUserInternalPermissionAuthorization UserInternalPermission { get; }
}
