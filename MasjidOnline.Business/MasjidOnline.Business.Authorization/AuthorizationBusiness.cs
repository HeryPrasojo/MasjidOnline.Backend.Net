using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Authorization;

public class AuthorizationBusiness : IAuthorizationBusiness
{
    public IAuthorizationAuthorizationBusiness Authorization { get; } = new AuthorizationAuthorizationBusiness();
    public IAccountancyAuthorizationBusiness Accountancy { get; } = new AccountancyAuthorizationBusiness();
    public IInfaqAuthorizationBusiness Infaq { get; } = new InfaqAuthorizationBusiness();
    public IUserAuthorizationBusiness User { get; } = new UserAuthorizationBusiness();

    public void AuthorizeAnonymous(Model.Session.Session session)
    {
        if (!session.IsUserAnonymous) throw new PermissionException(nameof(session.IsUserAnonymous));
    }

    public void AuthorizeNonAnonymous(Model.Session.Session session)
    {
        if (session.IsUserAnonymous) throw new PermissionException(nameof(session.IsUserAnonymous));
    }
}
