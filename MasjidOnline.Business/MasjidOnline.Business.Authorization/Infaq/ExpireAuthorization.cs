using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.Infaq;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Infaq;

internal class ExpireAuthorization : AuthorizationBase, IExpireAuthorization
{
    public async Task AuthorizeAddAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqExpireAdd: true);
    }

    public async Task AuthorizeApproveAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqExpireApprove: true);
    }

    public async Task AuthorizeCancelAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqExpireCancel: true);
    }
}
