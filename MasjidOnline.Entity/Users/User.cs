namespace MasjidOnline.Entity.Users;

public class User
{
    public required int Id { get; set; }

    public string Name { get; set; } = default!;

    public UserType UserType { get; set; }

    /// <summary>
    /// primary email address
    /// </summary>
    public int EmailAddressId { get; set; }

    public byte[]? Password { get; set; }
}
