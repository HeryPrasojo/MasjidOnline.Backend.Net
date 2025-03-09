using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.ViewModel.User.Internal;

public class ForApprove
{
    public required string EmailAddress { get; set; }

    public required InternalStatus Status { get; set; }
}
