using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Log;

public class LogSetting
{
    [Key]
    public required string Key { get; set; }

    public required string Value { get; set; }
}
