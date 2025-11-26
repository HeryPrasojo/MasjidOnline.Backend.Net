using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.Infaq;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Infaq;

internal class VoidAuthorization : AuthorizationBase, IVoidAuthorization
{
    public async Task AuthorizeAddAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqVoidAdd: true);
    }

    public async Task AuthorizeApproveAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqVoidApprove: true);
    }

    public async Task AuthorizeCancelAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqVoidCancel: true);
    }
}
