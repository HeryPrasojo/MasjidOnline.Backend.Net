using MasjidOnline.Business.Model.Authorization;

namespace MasjidOnline.Business.Model.User.User;

public class LoginResponse
{
    public required UserInternalPermission? Permission { get; set; }

    public required UserType? UserType { get; set; }
}
