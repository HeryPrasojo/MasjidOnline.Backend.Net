using MasjidOnline.Entity.User;

namespace MasjidOnline.Entity.Audit;

public class UserLog : Log<UserLogType>
{
    public required int UserId { get; set; }

    public UserStatus Status { get; set; }

    public UserType? Type { get; set; }

    public byte[]? Password { get; set; }
}
