using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.Infaq;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Infaq;

internal class VoidAuthorization : AuthorizationBase, IVoidAuthorization
{
    public async Task AuthorizeAddAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqVoidAdd: true);
    }

    public async Task AuthorizeApproveAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, infaqVoidApprove: true);
    }
}
