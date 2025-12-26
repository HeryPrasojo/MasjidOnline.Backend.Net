using MasjidOnline.Business.Model.User.UserPreference;

namespace MasjidOnline.Business.Model.User.User;

public class VerifySetPasswordRequest
{
    public string? CaptchaToken { get; set; }
    public string? PasswordCode { get; set; }
    public ContactType? ContactType { get; set; }
    public string? Contact { get; set; }
    public string? Password { get; set; }
    public string? Password2 { get; set; }
    public UserPreferenceApplicationCulture? ApplicationCulture { get; set; }
}
