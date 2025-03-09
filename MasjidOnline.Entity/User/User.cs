namespace MasjidOnline.Entity.User;

public class User
{
    public required int Id { get; set; }

    // todo move to person
    public string Name { get; set; } = default!;

    public UserStatus Status { get; set; }

    public UserType Type { get; set; }

    /// <summary>
    /// primary email address
    /// </summary>
    public string EmailAddress { get; set; } = default!;

    public byte[]? Password { get; set; }
}
