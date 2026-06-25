namespace MasjidOnline.Business.Authorization.Interface;

public interface IAuthorizationBusiness
{
    IAuthorizationAuthorizationBusiness Authorization { get; }
    IAccountancyAuthorizationBusiness Accountancy { get; }
    IUserAuthorizationBusiness User { get; }
    IDonationAuthorizationBusiness Donation { get; }

    void AuthorizeAnonymous(Model.Session.Session session);
    void AuthorizeNonAnonymous(Model.Session.Session session);
}


