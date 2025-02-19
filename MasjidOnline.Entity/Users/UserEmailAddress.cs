using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Users;

public class UserEmailAddress
{
    [Key]
    public required string EmailAddress { get; set; }

    public required int UserId { get; set; }
}
