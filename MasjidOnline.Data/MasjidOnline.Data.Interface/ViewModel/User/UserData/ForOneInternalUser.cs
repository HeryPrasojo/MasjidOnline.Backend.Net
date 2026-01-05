using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.ViewModel.User.UserData;

public class ForOneInternalUser
{
    public required int UserId { get; set; }

    public required ContactType MainContactType { get; set; }

    public required int MainContactId { get; set; }
}
