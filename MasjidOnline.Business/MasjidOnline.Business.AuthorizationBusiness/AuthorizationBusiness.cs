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
        IUserData _userData,
        bool infaqExpiredAdd = default,
        bool userInternalAdd = default,
        bool userInternalCancel = default)
    {
        var sessionPermission = await _userData.Permission.GetByUserIdAsync(_sessionBusiness.UserId);

        if (sessionPermission == default) throw new PermissionException(nameof(Constant.AnonymousUserId));

        if (infaqExpiredAdd && !sessionPermission.InfaqExpiredAdd) throw new PermissionException(nameof(sessionPermission.InfaqExpiredAdd));

        if (userInternalAdd && !sessionPermission.UserInternalAdd) throw new PermissionException(nameof(sessionPermission.UserInternalAdd));

        if (userInternalCancel && !sessionPermission.UserInternalCancel) throw new PermissionException(nameof(sessionPermission.UserInternalCancel));
    }
}
