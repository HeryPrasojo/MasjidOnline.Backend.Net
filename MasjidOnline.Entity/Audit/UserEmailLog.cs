namespace MasjidOnline.Entity.Audit;

public class UserEmailLog : Log<UserEmailLogType>
{
    public required int UserId { get; set; }

    public required string Address { get; set; }
}
