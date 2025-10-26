namespace MasjidOnline.Entity.DatabaseTemplate;

public class DatabaseTemplateSetting
{
    public required DatabaseTemplateSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
