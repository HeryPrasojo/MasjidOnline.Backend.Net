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
}
