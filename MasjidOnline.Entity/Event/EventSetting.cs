using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Event;

public class EventSetting
{
    [Key]
    public required string Key { get; set; }

    public required string Value { get; set; }
}
