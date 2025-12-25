using MasjidOnline.Business.Event.Interface.Model;

namespace MasjidOnline.Business.User.Interface.Model.User;

public class LoginRequest
{
    public string? CaptchaToken { get; set; }

    public ContactType? ContactType { get; set; }

    public string? Contact { get; set; }

    public string? Password { get; set; }

    public string? UserAgent { get; set; }

    public UserLoginClient? Client { get; set; }

    public double? LocationLatitude { get; set; }
    public double? LocationLongitude { get; set; }
    public double? LocationPrecision { get; set; }
    public double? LocationAltitude { get; set; }
    public double? LocationAltitudePrecision { get; set; }

    public string? IpAddress { get; set; }
}
