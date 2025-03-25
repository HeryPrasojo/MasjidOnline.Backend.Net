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
        if (_sessionBusiness.UserId == Constant.UserId.Anonymous) throw new PermissionException(nameof(Constant.UserId.Anonymous));
    }

    public async Task AuthorizePermissionAsync(
        ISessionBusiness _sessionBusiness,
        IUserDatabase _userDatabase,
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
        var sessionPermission = await _userDatabase.Permission.GetByUserIdAsync(_sessionBusiness.UserId);

        if (sessionPermission == default) throw new PermissionException(nameof(Constant.UserId.Anonymous));

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
