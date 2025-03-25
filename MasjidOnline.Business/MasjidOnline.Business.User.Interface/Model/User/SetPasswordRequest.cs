namespace MasjidOnline.Business.User.Interface.Model.User;

public class SetPasswordRequest
{
    public string? PasswordCode { get; set; }
    public string? Password { get; set; }
    public string? PasswordRepeat { get; set; }
}
