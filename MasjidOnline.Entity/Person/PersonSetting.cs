namespace MasjidOnline.Entity.Person;

public class PersonSetting
{
    public required PersonSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
