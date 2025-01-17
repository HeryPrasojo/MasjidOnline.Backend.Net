using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Users;

public class UserSetting
{
    [Key]
    public required string Key { get; set; }

    public required string Value { get; set; }
}
