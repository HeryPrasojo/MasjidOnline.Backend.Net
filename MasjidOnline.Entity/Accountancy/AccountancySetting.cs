namespace MasjidOnline.Entity.Accountancy;

public class AccountancySetting
{
    public required AccountancySettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
