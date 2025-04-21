using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Authorization;

public class AuthorizationBusiness : IAuthorizationBusiness
{
    public void AuthorizeNonAnonymous(Session.Interface.Model.Session session)
    {
        if (session.IsUserAnonymous) throw new PermissionException(nameof(session.IsUserAnonymous));
    }

    public async Task AuthorizePermissionAsync(
        Session.Interface.Model.Session session,
        IData _data,
        bool accountancyExpenditureAdd = default,
        bool accountancyExpenditureApprove = default,
        bool accountancyExpenditureCancel = default,
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
        if (session.IsUserAnonymous) throw new PermissionException(nameof(session.IsUserAnonymous));


        var sessionPermission = await _data.Authorization.UserInternalPermission.GetByUserIdAsync(session.UserId);

        if (sessionPermission == default) throw new PermissionException(nameof(session.UserId));


        if (accountancyExpenditureAdd && !sessionPermission.AccountancyExpenditureAdd) throw new PermissionException(nameof(sessionPermission.AccountancyExpenditureAdd));
        if (accountancyExpenditureApprove && !sessionPermission.AccountancyExpenditureApprove) throw new PermissionException(nameof(sessionPermission.AccountancyExpenditureApprove));
        if (accountancyExpenditureCancel && !sessionPermission.AccountancyExpenditureCancel) throw new PermissionException(nameof(sessionPermission.AccountancyExpenditureCancel));

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
