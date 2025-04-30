using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Interface;

public interface IAuthorizationBusiness
{
    void AuthorizeNonAnonymous(Session.Interface.Model.Session session);
    Task AuthorizePermissionAsync(Session.Interface.Model.Session session, IData _data, bool accountancyExpenditureAdd = false, bool accountancyExpenditureApprove = false, bool accountancyExpenditureCancel = false, bool infaqInternalAdd = false, bool infaqExpireAdd = false, bool infaqExpireApprove = false, bool infaqExpireCancel = false, bool infaqSuccessAdd = false, bool infaqSuccessApprove = false, bool infaqSuccessCancel = false, bool infaqVoidAdd = false, bool infaqVoidApprove = false, bool infaqVoidCancel = false, bool userInternalAdd = false, bool userInternalApprove = false, bool userInternalCancel = false);
}
