using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.Accountancy;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Accountancy;

internal class ExpenditureAuthorization : AuthorizationBase, IExpenditureAuthorization
{
    public async Task AuthorizeAddAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, accountancyExpenditureAdd: true);
    }

    public async Task AuthorizeApproveAync(Model.Session.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, accountancyExpenditureApprove: true);
    }
}
