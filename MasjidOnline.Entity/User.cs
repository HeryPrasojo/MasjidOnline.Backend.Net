namespace MasjidOnline.Entity;

public class User
{
    public required long Id { get; set; }

    /// <summary>
    /// primary email address
    /// </summary>
    public required string EmailAddress { get; set; }
}
