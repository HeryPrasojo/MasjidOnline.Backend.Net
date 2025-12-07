using MasjidOnline.Business.Authorization.Interface.Model;

namespace MasjidOnline.Business.User.Interface.Model.User;

public class LoginResponse
{
    public required UserInternalPermission? Permission { get; set; }

    // undone create in Authorization interface model
    public required UserType? UserType { get; set; }
}
