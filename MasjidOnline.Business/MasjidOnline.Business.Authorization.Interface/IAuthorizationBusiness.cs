namespace MasjidOnline.Business.Authorization.Interface;

public interface IAuthorizationBusiness
{
    IAuthorizationAuthorizationBusiness Authorization { get; }
    IAccountancyAuthorizationBusiness Accountancy { get; }
    IUserAuthorizationBusiness User { get; }
    IInfaqAuthorizationBusiness Infaq { get; }

    void AuthorizeAnonymous(Model.Session.Session session);
    void AuthorizeNonAnonymous(Model.Session.Session session);
}
