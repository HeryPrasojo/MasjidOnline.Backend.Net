using MasjidOnline.Business.Authorization.Interface.Model;

namespace MasjidOnline.Business.User.Interface.Model.User;

public class LoginResponse
{
    public required UserInternalPermission? Permission { get; set; }

    public required UserType? UserType { get; set; }
}
