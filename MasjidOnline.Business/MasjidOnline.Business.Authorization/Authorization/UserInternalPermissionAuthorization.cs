using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Authorization.UserInternalPermission;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Authorization.Interface.Authorization;
using MasjidOnline.Business.Authorization.Interface.Authorization.UserInternalPermission;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Authorization.Authorization;

internal class UserInternalPermissionAuthorization(
    IAuthorizationBusiness _authorizationBusiness,
    IService _service) : AuthorizationBase, IUserInternalPermissionAuthorization
{

    public async Task AuthorizeGetAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAnyAsync(_data, session, userInternalAdd: true, userInternalApprove: true, userInternalPermissionUpdate: true);
    }

    public IGetViewBusiness GetView { get; } = new GetViewBusiness(_authorizationBusiness, _service);
}
