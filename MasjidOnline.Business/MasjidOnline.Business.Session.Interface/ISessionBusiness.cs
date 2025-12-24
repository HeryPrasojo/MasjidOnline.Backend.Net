namespace MasjidOnline.Business.Session.Interface;

public interface ISessionBusiness
{
    ISessionCreateBusiness Create { get; }
    ISessionExpireBusiness Expire { get; }
    ISessionAuthenticationBusiness Authentication { get; }
}
