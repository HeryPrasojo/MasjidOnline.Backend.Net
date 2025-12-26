using MasjidOnline.Business.Model.User.UserPreference;

namespace MasjidOnline.Business.Model.Session.Sessions;

public class CreateRequest
{
    public string? CaptchaToken { get; set; }

    public UserPreferenceApplicationCulture? ApplicationCulture { get; set; }
}
