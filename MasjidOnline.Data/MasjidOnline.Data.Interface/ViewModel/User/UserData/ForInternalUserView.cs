using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.ViewModel.User.UserData;

public class ForInternalUserView
{
    public required int UserId { get; set; }

    public required ContactType MainContactType { get; set; }

    public required int MainContactId { get; set; }
}
