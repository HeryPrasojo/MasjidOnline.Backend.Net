namespace MasjidOnline.Business.Authorization.Interface;

public interface IAuthorizationBusiness
{
    IAccountancyAuthorizationBusiness Accountancy { get; }
    IUserAuthorizationBusiness User { get; }
    IInfaqAuthorizationBusiness Infaq { get; }

    void AuthorizeNonAnonymous(Session.Interface.Model.Session session);
}
