using MasjidOnline.Entity.User;

namespace MasjidOnline.Entity.Audit;

public class UserDataLog : Log<UserDataLogType>
{
    public required int UserId { get; set; }

    public required ApplicationCulture? ApplicationCulture { get; set; }

    public required bool IsAcceptAgreement { get; set; }
}
