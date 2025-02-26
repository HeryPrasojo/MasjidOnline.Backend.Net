using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.AuthorizationBusiness;

public class AuthorizationBusiness : IAuthorizationBusiness
{
    public void AuthorizeNonAnonymous(ISessionBusiness _sessionBusiness)
    {
        if (_sessionBusiness.UserId == Constant.AnonymousUserId) throw new PermissionException(nameof(Constant.AnonymousUserId));
    }

    public async Task AuthorizePermissionAsync(
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        bool infaqSetPaymentStatusExpired = default,
        bool userAddInternal = default)
    {
        var sessionPermission = await _usersData.Permission.GetByUserIdAsync(_sessionBusiness.UserId);

        if (sessionPermission == default) throw new PermissionException(nameof(Constant.AnonymousUserId));

        if (infaqSetPaymentStatusExpired && !sessionPermission.InfaqSetPaymentStatusExpired) throw new PermissionException(nameof(sessionPermission.InfaqSetPaymentStatusExpired));

        if (userAddInternal && !sessionPermission.UserAddInternal) throw new PermissionException(nameof(sessionPermission.UserAddInternal));
    }
}
