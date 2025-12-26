using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.User;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.User;

internal class InternalAuthorization : AuthorizationBase, IInternalAuthorization
{
    public async Task AuthorizeAddAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, userInternalAdd: true);
    }

    public async Task AuthorizeApproveAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, userInternalApprove: true);
    }

    public async Task AuthorizeCancelAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, userInternalCancel: true);
    }

    public async Task AuthorizeReadAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAnyAsync(_data, session, userInternalAdd: true, userInternalApprove: true, userInternalCancel: true);
    }
}
