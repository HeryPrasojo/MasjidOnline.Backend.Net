using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Audit;

public class AuditSetting
{
    // todo move primary key to enum, use this as description.
    [Key]
    public required string Key { get; set; }

    public required string Value { get; set; }
}
