namespace MasjidOnline.Business.User.Interface;

public interface IUserBusiness
{
    IUserInternalBusiness Internal { get; }
    IUserUserBusiness User { get; }
    IUserPreferenceBusiness UserPreference { get; }
}
