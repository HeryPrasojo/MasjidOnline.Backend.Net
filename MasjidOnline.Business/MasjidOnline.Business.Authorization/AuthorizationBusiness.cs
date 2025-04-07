using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Authorization;

public class AuthorizationBusiness : IAuthorizationBusiness
{
    public void AuthorizeNonAnonymous(Session.Interface.Session _sessionBusiness)
    {
        if (_sessionBusiness.IsUserAnonymous) throw new PermissionException(nameof(_sessionBusiness.IsUserAnonymous));
    }

    public async Task AuthorizePermissionAsync(
        Session.Interface.Session _sessionBusiness,
        IData _data,
        bool infaqExpireAdd = default,
        bool infaqExpireApprove = default,
        bool infaqExpireCancel = default,
        bool infaqSuccessAdd = default,
        bool infaqSuccessApprove = default,
        bool infaqSuccessCancel = default,
        bool infaqVoidAdd = default,
        bool infaqVoidApprove = default,
        bool infaqVoidCancel = default,
        bool userInternalAdd = default,
        bool userInternalApprove = default,
        bool userInternalCancel = default)
    {
        if (_sessionBusiness.IsUserAnonymous) throw new PermissionException(nameof(_sessionBusiness.IsUserAnonymous));

        var sessionPermission = await _data.Authorization.UserInternalPermission.GetByUserIdAsync(_sessionBusiness.UserId);

        if (sessionPermission == default) throw new PermissionException(nameof(_sessionBusiness.UserId));

        if (infaqExpireAdd && !sessionPermission.InfaqExpireAdd) throw new PermissionException(nameof(sessionPermission.InfaqExpireAdd));
        if (infaqExpireApprove && !sessionPermission.InfaqExpireApprove) throw new PermissionException(nameof(sessionPermission.InfaqExpireApprove));
        if (infaqExpireCancel && !sessionPermission.InfaqExpireCancel) throw new PermissionException(nameof(sessionPermission.InfaqExpireCancel));

        if (infaqSuccessAdd && !sessionPermission.InfaqSuccessAdd) throw new PermissionException(nameof(sessionPermission.InfaqSuccessAdd));
        if (infaqSuccessApprove && !sessionPermission.InfaqSuccessApprove) throw new PermissionException(nameof(sessionPermission.InfaqSuccessApprove));
        if (infaqSuccessCancel && !sessionPermission.InfaqSuccessCancel) throw new PermissionException(nameof(sessionPermission.InfaqSuccessCancel));

        if (infaqVoidAdd && !sessionPermission.InfaqVoidAdd) throw new PermissionException(nameof(sessionPermission.InfaqVoidAdd));
        if (infaqVoidApprove && !sessionPermission.InfaqVoidApprove) throw new PermissionException(nameof(sessionPermission.InfaqVoidApprove));
        if (infaqVoidCancel && !sessionPermission.InfaqVoidCancel) throw new PermissionException(nameof(sessionPermission.InfaqVoidCancel));

        if (userInternalAdd && !sessionPermission.UserInternalAdd) throw new PermissionException(nameof(sessionPermission.UserInternalAdd));
        if (userInternalApprove && !sessionPermission.UserInternalApprove) throw new PermissionException(nameof(sessionPermission.UserInternalApprove));
        if (userInternalCancel && !sessionPermission.UserInternalCancel) throw new PermissionException(nameof(sessionPermission.UserInternalCancel));
    }
}
