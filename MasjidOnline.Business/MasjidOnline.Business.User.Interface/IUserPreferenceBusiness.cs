using MasjidOnline.Business.User.Interface.UserPreference;

namespace MasjidOnline.Business.User.Interface;

public interface IUserPreferenceBusiness
{
    ISetApplicationCultureBusiness SetApplicationCulture { get; }
}
