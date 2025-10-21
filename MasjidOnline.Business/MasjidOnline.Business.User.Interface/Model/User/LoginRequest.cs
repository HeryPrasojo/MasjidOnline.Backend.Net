namespace MasjidOnline.Business.User.Interface.Model.User;

public class LoginRequest
{
    public string? CaptchaToken { get; set; }

    public string? EmailAddress { get; set; }

    public string? Password { get; set; }
}
