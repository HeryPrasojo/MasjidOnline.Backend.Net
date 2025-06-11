using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.UserPreference;
using MasjidOnline.Business.User.UserPreference;

namespace MasjidOnline.Business.User;

public class UserPreferenceBusiness : IUserPreferenceBusiness
{
    public ISetApplicationCultureBusiness SetApplicationCulture { get; } = new SetApplicationCultureBusiness();
}
