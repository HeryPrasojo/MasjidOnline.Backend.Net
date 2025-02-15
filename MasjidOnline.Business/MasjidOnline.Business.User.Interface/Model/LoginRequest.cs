namespace MasjidOnline.Business.User.Interface.Model;

public class LoginRequest
{
    public required string EmailAddress { get; set; }

    public required string Password { get; set; }
}
