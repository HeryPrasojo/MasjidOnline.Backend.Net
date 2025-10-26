namespace MasjidOnline.Entity.Authorization;

public class AuthorizationSetting
{
    public required AuthorizationSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
