namespace MasjidOnline.Entity.Event;

public class EventSetting
{
    public required EventSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
