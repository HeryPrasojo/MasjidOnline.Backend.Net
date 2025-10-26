namespace MasjidOnline.Entity.User;

public class UserSetting
{
    public required UserSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
