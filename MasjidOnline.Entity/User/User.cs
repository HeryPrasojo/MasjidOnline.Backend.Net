namespace MasjidOnline.Entity.User;

public class User
{
    public required int Id { get; set; }

    public UserStatus Status { get; set; }

    public UserType Type { get; set; }

    public byte[]? Password { get; set; }
}
