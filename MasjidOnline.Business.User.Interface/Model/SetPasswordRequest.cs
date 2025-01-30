namespace MasjidOnline.Business.User.Interface.Model;

public class SetPasswordRequest
{
    public required byte[] PasswordCode { get; set; }
    public required string PasswordCodeText { get; set; }
    public required string Password { get; set; }
    public required string PasswordRepeat { get; set; }
}
