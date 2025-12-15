using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.ViewModel.User.User;

public class ForLogin
{
    public required byte[]? Password { get; set; }

    public required UserStatus Status { get; set; }

    public required UserType Type { get; set; }
}
