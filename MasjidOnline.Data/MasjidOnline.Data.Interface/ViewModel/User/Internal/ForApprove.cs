using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.ViewModel.User.Internal;

public class ForApprove
{
    public int UserId { get; set; }

    public required InternalUserStatus Status { get; set; }
}
