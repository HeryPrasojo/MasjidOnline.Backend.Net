namespace MasjidOnline.Entity.Audit;

public class UserEmailAddressLog : Log<UserEmailAddressLogType>
{
    public required int UserId { get; set; }

    public required string EmailAddress { get; set; }
}
