using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Authorization;

public class AuthorizationBusiness : IAuthorizationBusiness
{
    public IAccountancyAuthorizationBusiness Accountancy { get; } = new AccountancyAuthorizationBusiness();
    public IInfaqAuthorizationBusiness Infaq { get; } = new InfaqAuthorizationBusiness();
    public IUserAuthorizationBusiness User { get; } = new UserAuthorizationBusiness();

    public void AuthorizeAnonymous(Session.Interface.Model.Session session)
    {
        if (!session.IsUserAnonymous) throw new PermissionException(nameof(session.IsUserAnonymous));
    }

    public void AuthorizeNonAnonymous(Session.Interface.Model.Session session)
    {
        if (session.IsUserAnonymous) throw new PermissionException(nameof(session.IsUserAnonymous));
    }
}
