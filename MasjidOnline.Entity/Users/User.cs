namespace MasjidOnline.Entity.Users;

public class User
{
    public required int Id { get; set; }

    public string Name { get; set; } = default!;

    public UserType Type { get; set; }

    /// <summary>
    /// primary email address
    /// </summary>
    public string EmailAddress { get; set; } = default!;

    public byte[]? Password { get; set; }
}
