namespace MasjidOnline.Entity.Audit;

public class AuditSetting
{
    public required AuditSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
