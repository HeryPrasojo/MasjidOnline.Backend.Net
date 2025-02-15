using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.AuthorizationBusiness.Interface;

public interface IAuthorizationBusiness
{
    void AuthorizeNonAnonymous(ISessionBusiness _sessionBusiness);
    Task AuthorizePermissionAsync(ISessionBusiness _sessionBusiness, IUsersData _usersData, bool transactionInfaqRead = false, bool userInternalAdd = false);
}
