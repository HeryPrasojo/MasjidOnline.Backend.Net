using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Authorization;

internal abstract class AuthorizationBase
{
    protected async Task AuthorizePermissionAsync(
        Session.Interface.Model.Session session,
        IData _data,
        bool accountancyExpenditureAdd = default,
        bool accountancyExpenditureApprove = default,
        bool accountancyExpenditureCancel = default,
        bool infaqOnBehalfAdd = default,
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


        var userInternalPermission = await _data.Authorization.UserInternalPermission.FirstOrDefaultAsync(session.UserId);

        if (userInternalPermission == default) throw new PermissionException(nameof(session.UserId));


        if (accountancyExpenditureAdd && !userInternalPermission.AccountancyExpenditureAdd) throw new PermissionException(nameof(userInternalPermission.AccountancyExpenditureAdd));
        if (accountancyExpenditureApprove && !userInternalPermission.AccountancyExpenditureApprove) throw new PermissionException(nameof(userInternalPermission.AccountancyExpenditureApprove));
        if (accountancyExpenditureCancel && !userInternalPermission.AccountancyExpenditureCancel) throw new PermissionException(nameof(userInternalPermission.AccountancyExpenditureCancel));

        if (infaqOnBehalfAdd && !userInternalPermission.InfaqOnBehalfAdd) throw new PermissionException(nameof(userInternalPermission.InfaqOnBehalfAdd));

        if (infaqExpireAdd && !userInternalPermission.InfaqExpireAdd) throw new PermissionException(nameof(userInternalPermission.InfaqExpireAdd));
        if (infaqExpireApprove && !userInternalPermission.InfaqExpireApprove) throw new PermissionException(nameof(userInternalPermission.InfaqExpireApprove));
        if (infaqExpireCancel && !userInternalPermission.InfaqExpireCancel) throw new PermissionException(nameof(userInternalPermission.InfaqExpireCancel));

        if (infaqSuccessAdd && !userInternalPermission.InfaqSuccessAdd) throw new PermissionException(nameof(userInternalPermission.InfaqSuccessAdd));
        if (infaqSuccessApprove && !userInternalPermission.InfaqSuccessApprove) throw new PermissionException(nameof(userInternalPermission.InfaqSuccessApprove));
        if (infaqSuccessCancel && !userInternalPermission.InfaqSuccessCancel) throw new PermissionException(nameof(userInternalPermission.InfaqSuccessCancel));

        if (infaqVoidAdd && !userInternalPermission.InfaqVoidAdd) throw new PermissionException(nameof(userInternalPermission.InfaqVoidAdd));
        if (infaqVoidApprove && !userInternalPermission.InfaqVoidApprove) throw new PermissionException(nameof(userInternalPermission.InfaqVoidApprove));
        if (infaqVoidCancel && !userInternalPermission.InfaqVoidCancel) throw new PermissionException(nameof(userInternalPermission.InfaqVoidCancel));

        if (userInternalAdd && !userInternalPermission.UserInternalAdd) throw new PermissionException(nameof(userInternalPermission.UserInternalAdd));
        if (userInternalApprove && !userInternalPermission.UserInternalApprove) throw new PermissionException(nameof(userInternalPermission.UserInternalApprove));
        if (userInternalCancel && !userInternalPermission.UserInternalCancel) throw new PermissionException(nameof(userInternalPermission.UserInternalCancel));
    }
}
