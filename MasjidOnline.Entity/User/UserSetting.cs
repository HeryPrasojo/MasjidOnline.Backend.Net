namespace MasjidOnline.Entity.User;

public class UserSetting
{
    // todo medium change int to enum
    public required int Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
