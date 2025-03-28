using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Interface;

public interface IAuthorizationBusiness
{
    void AuthorizeNonAnonymous(ISessionBusiness _sessionBusiness);
    Task AuthorizePermissionAsync(ISessionBusiness _sessionBusiness, IData _data, bool infaqExpireAdd = false, bool infaqExpireApprove = false, bool infaqExpireCancel = false, bool infaqSuccessAdd = false, bool infaqSuccessApprove = false, bool infaqSuccessCancel = false, bool infaqVoidAdd = false, bool infaqVoidApprove = false, bool infaqVoidCancel = false, bool userInternalAdd = false, bool userInternalApprove = false, bool userInternalCancel = false);
}
