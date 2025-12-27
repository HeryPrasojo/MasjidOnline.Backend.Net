using MasjidOnline.Business.Model.Event;

namespace MasjidOnline.Business.Model.User.User;

public class VerifyRegisterRequest
{
    public string? CaptchaToken { get; set; }
    public string? RegisterCode { get; set; }
    public ContactType? ContactType { get; set; }
    public string? Contact { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public string? Password2 { get; set; }
    public bool? IsAcceptAgreement { get; set; }

    public string? UserAgent { get; set; }

    public UserLoginClient? Client { get; set; }

    public double? LocationLatitude { get; set; }
    public double? LocationLongitude { get; set; }
    public double? LocationPrecision { get; set; }
    public double? LocationAltitude { get; set; }
    public double? LocationAltitudePrecision { get; set; }

    public string? IpAddress { get; set; }
}
