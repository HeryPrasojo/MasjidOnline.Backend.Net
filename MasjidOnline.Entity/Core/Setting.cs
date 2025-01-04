using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Core;

public class Setting
{
    [Key]
    public required string Key { get; set; }

    public required string Value { get; set; }
}
