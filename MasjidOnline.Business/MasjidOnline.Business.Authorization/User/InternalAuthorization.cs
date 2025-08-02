using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.User;

internal class InternalAuthorization : AuthorizationBase, IInternalAuthorization
{
    public async Task AuthorizeAddAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAsync(session, _data, userInternalAdd: true);
    }

    public async Task AuthorizeApproveAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAsync(session, _data, userInternalApprove: true);
    }

    public async Task AuthorizeCancelAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAsync(session, _data, userInternalCancel: true);
    }
}
