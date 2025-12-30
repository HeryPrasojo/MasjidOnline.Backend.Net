using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.ViewModel.User.User;

public class ForInternalAdd
{
    public required UserStatus Status { get; set; }

    public required UserType Type { get; set; }
}
