using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.Authorization;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Authorization;

internal class UserInternalPermissionAuthorization : AuthorizationBase, IUserInternalPermissionAuthorization
{

    public async Task AuthorizeGetAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAnyAsync(_data, session, userInternalPermissionUpdate: true);
    }
}
