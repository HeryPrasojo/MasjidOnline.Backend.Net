namespace MasjidOnline.Entity.Users;

public class User
{
    public required int Id { get; set; }

    public required string Name { get; set; }

    public required UserType UserType { get; set; }

    /// <summary>
    /// primary email address
    /// </summary>
    public required int EmailAddressId { get; set; }

    public string? Password { get; set; }
}
