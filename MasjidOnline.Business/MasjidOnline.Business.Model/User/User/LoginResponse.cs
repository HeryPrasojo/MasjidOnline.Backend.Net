using MasjidOnline.Business.Model.Authorization;
using MasjidOnline.Business.Model.User.UserPreference;

namespace MasjidOnline.Business.Model.User.User;

public class LoginResponse
{
    public required UserInternalPermission? Permission { get; set; }

    public required UserType? UserType { get; set; }

    public required UserPreferenceApplicationCulture? ApplicationCulture { get; set; }
}
