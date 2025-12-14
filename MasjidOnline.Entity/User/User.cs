namespace MasjidOnline.Entity.User;

public class User
{
    public required int Id { get; set; }

    public UserStatus Status { get; set; }

    public UserType Type { get; set; }

    public required byte[] Password { get; set; }
}
