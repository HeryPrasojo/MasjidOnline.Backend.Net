using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.User;

public class UserData
{
    [Key]
    public required int UserId { get; set; }

    public required ApplicationCulture ApplicationCulture { get; set; }
}
