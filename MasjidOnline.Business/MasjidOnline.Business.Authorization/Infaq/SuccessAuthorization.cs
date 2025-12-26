using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.Infaq;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Infaq;

internal class SuccessAuthorization : AuthorizationBase, ISuccessAuthorization
{
    public async Task AuthorizeAddAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqSuccessAdd: true);
    }

    public async Task AuthorizeApproveAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqSuccessApprove: true);
    }

    public async Task AuthorizeCancelAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqSuccessCancel: true);
    }
}
