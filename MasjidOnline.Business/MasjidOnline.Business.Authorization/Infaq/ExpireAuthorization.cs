using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.Infaq;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Infaq;

internal class ExpireAuthorization : AuthorizationBase, IExpireAuthorization
{
    public async Task AuthorizeAddAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqExpireAdd: true);
    }

    public async Task AuthorizeApproveAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqExpireApprove: true);
    }
}
