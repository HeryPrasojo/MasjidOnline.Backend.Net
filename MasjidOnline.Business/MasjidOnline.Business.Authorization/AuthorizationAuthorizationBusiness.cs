using MasjidOnline.Business.Authorization.Authorization;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Authorization.Interface.Authorization;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Authorization;

public class AuthorizationAuthorizationBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IAuthorizationAuthorizationBusiness
{
    public IUserInternalPermissionAuthorization UserInternalPermission { get; } = new UserInternalPermissionAuthorization(_authorizationBusiness, _service);

}
