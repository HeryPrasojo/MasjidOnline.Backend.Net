namespace MasjidOnline.Business.User.Interface.Model.User;

public class SetPasswordRequest
{
    public string? CaptchaToken { get; set; }
    public string? PasswordCode { get; set; }
    public string? Password { get; set; }
    public string? Password2 { get; set; }
}
