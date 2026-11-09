namespace MasjidOnline.Entity.ContactList;

public class ContactListSetting
{
    public required ContactListSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
