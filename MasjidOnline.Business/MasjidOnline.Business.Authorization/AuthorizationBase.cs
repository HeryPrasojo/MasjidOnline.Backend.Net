using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Authorization;

internal abstract class AuthorizationBase
{
    protected static async Task AuthorizeInternalAsync(IData _data, Model.Session.Session session)
    {
        if (session.IsUserAnonymous) throw new PermissionException(nameof(session.IsUserAnonymous));


        var userType = await _data.User.User.GetTypeAsync(session.UserId);

        if (userType != UserType.Internal) throw new PermissionException(nameof(UserType));
    }

    protected static async Task AuthorizePermissionAllAsync(
        IData _data,
        Model.Session.Session session,
        bool accountancyExpenditureAdd = default,
        bool accountancyExpenditureApprove = default,
        bool infaqStatusRequest = default,
        bool infaqStatusApprove = default,
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


        if (infaqStatusRequest && !userInternalPermission.InfaqStatusRequest)
            throw new PermissionException(nameof(userInternalPermission.InfaqStatusRequest));

        if (infaqStatusApprove && !userInternalPermission.InfaqStatusApprove)
            throw new PermissionException(nameof(userInternalPermission.InfaqStatusApprove));


        if (userInternalAdd && !userInternalPermission.UserInternalAdd)
            throw new PermissionException(nameof(userInternalPermission.UserInternalAdd));

        if (userInternalApprove && !userInternalPermission.UserInternalApprove)
            throw new PermissionException(nameof(userInternalPermission.UserInternalApprove));


        if (userInternalPermissionUpdate && !userInternalPermission.UserInternalPermissionUpdate)
            throw new PermissionException(nameof(userInternalPermission.UserInternalPermissionUpdate));
    }
}
