using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Authorization;

internal abstract class AuthorizationBase
{
    protected static async Task AuthorizePermissionAllAsync(
        IData _data,
        Session.Interface.Model.Session session,
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
        await AuthorizeInternalAsync(_data, session);


        var userInternalPermission = await _data.Authorization.UserInternalPermission.FirstOrDefaultAsync(session.UserId);

        if (userInternalPermission == default) throw new PermissionException(nameof(session.UserId));


        if (accountancyExpenditureAdd && !userInternalPermission.AccountancyExpenditureAdd) throw new PermissionException(nameof(userInternalPermission.AccountancyExpenditureAdd));
        if (accountancyExpenditureApprove && !userInternalPermission.AccountancyExpenditureApprove) throw new PermissionException(nameof(userInternalPermission.AccountancyExpenditureApprove));
        if (accountancyExpenditureCancel && !userInternalPermission.AccountancyExpenditureCancel) throw new PermissionException(nameof(userInternalPermission.AccountancyExpenditureCancel));

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
        if (userInternalApprove && !userInternalPermission.UserInternalApprove) return;
        if (userInternalCancel && !userInternalPermission.UserInternalCancel) return;
    }

    protected static async Task AuthorizePermissionAnyAsync(
        IData _data,
        Session.Interface.Model.Session session,
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
        await AuthorizeInternalAsync(_data, session);


        var userInternalPermission = await _data.Authorization.UserInternalPermission.FirstOrDefaultAsync(session.UserId);

        if (userInternalPermission == default) throw new PermissionException(nameof(session.UserId));


        if (accountancyExpenditureAdd && userInternalPermission.AccountancyExpenditureAdd) return;
        if (accountancyExpenditureApprove && userInternalPermission.AccountancyExpenditureApprove) return;
        if (accountancyExpenditureCancel && userInternalPermission.AccountancyExpenditureCancel) return;

        if (infaqExpireAdd && userInternalPermission.InfaqExpireAdd) return;
        if (infaqExpireApprove && userInternalPermission.InfaqExpireApprove) return;
        if (infaqExpireCancel && userInternalPermission.InfaqExpireCancel) return;

        if (infaqSuccessAdd && userInternalPermission.InfaqSuccessAdd) return;
        if (infaqSuccessApprove && userInternalPermission.InfaqSuccessApprove) return;
        if (infaqSuccessCancel && userInternalPermission.InfaqSuccessCancel) return;

        if (infaqVoidAdd && userInternalPermission.InfaqVoidAdd) return;
        if (infaqVoidApprove && userInternalPermission.InfaqVoidApprove) return;
        if (infaqVoidCancel && userInternalPermission.InfaqVoidCancel) return;

        if (userInternalAdd && userInternalPermission.UserInternalAdd) return;
        if (userInternalApprove && userInternalPermission.UserInternalApprove) return;
        if (userInternalCancel && userInternalPermission.UserInternalCancel) return;

        throw new PermissionException(nameof(userInternalPermission));
    }

    private static async Task AuthorizeInternalAsync(IData _data, Session.Interface.Model.Session session)
    {
        if (session.IsUserAnonymous) throw new PermissionException(nameof(session.IsUserAnonymous));


        var userType = await _data.User.User.GetTypeAsync(session.UserId);

        if (userType != UserType.Internal) throw new PermissionException(nameof(UserType));
    }
}
