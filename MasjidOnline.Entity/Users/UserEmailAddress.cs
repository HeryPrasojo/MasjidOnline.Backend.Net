namespace MasjidOnline.Entity.Users;

public class UserEmailAddress
{
    public virtual required int Id { get; set; }

    public required int UserId { get; set; }

    public required string EmailAddress { get; set; }

    public required bool Disabled { get; set; }
}
