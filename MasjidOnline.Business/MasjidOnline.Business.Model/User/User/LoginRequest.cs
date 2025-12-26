using MasjidOnline.Business.Model.Event;
using MasjidOnline.Business.Model.User.UserPreference;

namespace MasjidOnline.Business.Model.User.User;

public class LoginRequest
{
    public string? CaptchaToken { get; set; }

    public ContactType? ContactType { get; set; }

    public string? Contact { get; set; }

    public string? Password { get; set; }

    public string? UserAgent { get; set; }

    public UserLoginClient? Client { get; set; }

    public UserPreferenceApplicationCulture? ApplicationCulture { get; set; }

    public double? LocationLatitude { get; set; }
    public double? LocationLongitude { get; set; }
    public double? LocationPrecision { get; set; }
    public double? LocationAltitude { get; set; }
    public double? LocationAltitudePrecision { get; set; }

    public string? IpAddress { get; set; }
}
