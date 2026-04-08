using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Authorization;

public class AuthorizationBusiness : IAuthorizationBusiness
{
    public AuthorizationBusiness(IService _service)
    {
        Authorization = new AuthorizationAuthorizationBusiness(this, _service);
    }

    public IAuthorizationAuthorizationBusiness Authorization { get; }
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
