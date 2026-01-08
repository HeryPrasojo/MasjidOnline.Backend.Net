using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Authorization;

internal abstract class AuthorizationBase
{
    protected static async Task AuthorizePermissionAllAsync(
        IData _data,
        Model.Session.Session session,
        bool accountancyExpenditureAdd = default,
        bool accountancyExpenditureApprove = default,
        bool infaqExpireAdd = default,
        bool infaqExpireApprove = default,
        bool infaqSuccessAdd = default,
        bool infaqSuccessApprove = default,
        bool infaqVoidAdd = default,
        bool infaqVoidApprove = default,
        bool userInternalAdd = default,
        bool userInternalApprove = default,
        bool userInternalPermissionUpdate = default)
    {
        await AuthorizeInternalAsync(_data, session);


        var userInternalPermission = await _data.Authorization.UserInternalPermission.FirstOrDefaultAsync(session.UserId);

        if (userInternalPermission == default) throw new PermissionException(nameof(session.UserId));


        if (accountancyExpenditureAdd && !userInternalPermission.AccountancyExpenditureAdd)
            throw new PermissionException(nameof(userInternalPermission.AccountancyExpenditureAdd));

        if (accountancyExpenditureApprove && !userInternalPermission.AccountancyExpenditureApprove)
            throw new PermissionException(nameof(userInternalPermission.AccountancyExpenditureApprove));


        if (infaqExpireAdd && !userInternalPermission.InfaqExpireAdd)
            throw new PermissionException(nameof(userInternalPermission.InfaqExpireAdd));

        if (infaqExpireApprove && !userInternalPermission.InfaqExpireApprove)
            throw new PermissionException(nameof(userInternalPermission.InfaqExpireApprove));


        if (infaqSuccessAdd && !userInternalPermission.InfaqSuccessAdd)
            throw new PermissionException(nameof(userInternalPermission.InfaqSuccessAdd));

        if (infaqSuccessApprove && !userInternalPermission.InfaqSuccessApprove)
            throw new PermissionException(nameof(userInternalPermission.InfaqSuccessApprove));


        if (infaqVoidAdd && !userInternalPermission.InfaqVoidAdd)
            throw new PermissionException(nameof(userInternalPermission.InfaqVoidAdd));

        if (infaqVoidApprove && !userInternalPermission.InfaqVoidApprove)
            throw new PermissionException(nameof(userInternalPermission.InfaqVoidApprove));


        if (userInternalAdd && !userInternalPermission.UserInternalAdd)
            throw new PermissionException(nameof(userInternalPermission.UserInternalAdd));

        if (userInternalApprove && !userInternalPermission.UserInternalApprove)
            throw new PermissionException(nameof(userInternalPermission.UserInternalApprove));


        if (userInternalPermissionUpdate && !userInternalPermission.UserInternalPermissionUpdate)
            throw new PermissionException(nameof(userInternalPermission.UserInternalPermissionUpdate));
    }

    protected static async Task AuthorizePermissionAnyAsync(
        IData _data,
        Model.Session.Session session,
        bool accountancyExpenditureAdd = default,
        bool accountancyExpenditureApprove = default,
        bool infaqExpireAdd = default,
        bool infaqExpireApprove = default,
        bool infaqSuccessAdd = default,
        bool infaqSuccessApprove = default,
        bool infaqVoidAdd = default,
        bool infaqVoidApprove = default,
        bool userInternalAdd = default,
        bool userInternalApprove = default,
        bool userInternalPermissionUpdate = default)
    {
        await AuthorizeInternalAsync(_data, session);


        var userInternalPermission = await _data.Authorization.UserInternalPermission.FirstOrDefaultAsync(session.UserId);

        if (userInternalPermission == default) throw new PermissionException(nameof(session.UserId));


        if (accountancyExpenditureAdd && userInternalPermission.AccountancyExpenditureAdd) return;
        if (accountancyExpenditureApprove && userInternalPermission.AccountancyExpenditureApprove) return;

        if (infaqExpireAdd && userInternalPermission.InfaqExpireAdd) return;
        if (infaqExpireApprove && userInternalPermission.InfaqExpireApprove) return;

        if (infaqSuccessAdd && userInternalPermission.InfaqSuccessAdd) return;
        if (infaqSuccessApprove && userInternalPermission.InfaqSuccessApprove) return;

        if (infaqVoidAdd && userInternalPermission.InfaqVoidAdd) return;
        if (infaqVoidApprove && userInternalPermission.InfaqVoidApprove) return;

        if (userInternalAdd && userInternalPermission.UserInternalAdd) return;
        if (userInternalApprove && userInternalPermission.UserInternalApprove) return;

        if (userInternalPermissionUpdate && userInternalPermission.UserInternalPermissionUpdate) return;

        throw new PermissionException(nameof(userInternalPermission));
    }

    private static async Task AuthorizeInternalAsync(IData _data, Model.Session.Session session)
    {
        if (session.IsUserAnonymous) throw new PermissionException(nameof(session.IsUserAnonymous));


        var userType = await _data.User.User.GetTypeAsync(session.UserId);

        if (userType != UserType.Internal) throw new PermissionException(nameof(UserType));
    }
}
