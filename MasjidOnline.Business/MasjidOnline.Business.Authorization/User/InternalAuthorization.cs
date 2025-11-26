using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.User;

internal class InternalAuthorization : AuthorizationBase, IInternalAuthorization
{
    public async Task AuthorizeAddAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, userInternalAdd: true);
    }

    public async Task AuthorizeApproveAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, userInternalApprove: true);
    }

    public async Task AuthorizeCancelAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, userInternalCancel: true);
    }

    public async Task AuthorizeReadAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAnyAsync(_data, session, userInternalAdd: true, userInternalApprove: true, userInternalCancel: true);
    }
}
