using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface.Accountancy;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Accountancy;

internal class ExpenditureAuthorization : AuthorizationBase, IExpenditureAuthorization
{
    public async Task AuthorizeAddAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, accountancyExpenditureAdd: true);
    }

    public async Task AuthorizeApproveAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, accountancyExpenditureApprove: true);
    }

    public async Task AuthorizeCancelAync(Session.Interface.Model.Session session, IData _data)
    {
        await AuthorizePermissionAllAsync(_data, session, accountancyExpenditureCancel: true);
    }
}
