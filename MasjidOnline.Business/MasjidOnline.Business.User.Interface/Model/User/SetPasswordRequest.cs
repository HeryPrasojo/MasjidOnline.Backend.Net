namespace MasjidOnline.Business.User.Interface.Model.User;

public class SetPasswordRequest
{
    public string? Code { get; set; }
    public string? Password { get; set; }
    public string? Password2 { get; set; }
}
