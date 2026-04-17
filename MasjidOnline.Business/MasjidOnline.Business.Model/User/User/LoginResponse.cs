using MasjidOnline.Business.Model.Authorization.UserInternalPermission;
using MasjidOnline.Business.Model.User.UserData;

namespace MasjidOnline.Business.Model.User.User;

public class LoginResponse
{
    public required ApplicationCulture? ApplicationCulture { get; set; }

    public required ForLoginResponse? Permission { get; set; }

    public required string? PersonName { get; set; }

    public required int UserId { get; set; }

    public required UserType? UserType { get; set; }
}
