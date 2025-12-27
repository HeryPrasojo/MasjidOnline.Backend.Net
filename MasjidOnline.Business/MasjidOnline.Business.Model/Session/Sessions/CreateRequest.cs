using MasjidOnline.Business.Model.User.UserData;

namespace MasjidOnline.Business.Model.Session.Sessions;

public class CreateRequest
{
    public string? CaptchaToken { get; set; }

    public ApplicationCulture? ApplicationCulture { get; set; }
}
