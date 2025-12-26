namespace MasjidOnline.Business.Model.User.User;

public class RegisterRequest
{
    public string? CaptchaToken { get; set; }
    public ContactType? ContactType { get; set; }
    public string? Contact { get; set; }
    public bool? IsTncAgree { get; set; }
}
