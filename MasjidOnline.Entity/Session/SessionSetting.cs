namespace MasjidOnline.Entity.Session;

public class SessionSetting
{
    public required SessionSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
