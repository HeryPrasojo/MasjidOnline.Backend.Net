namespace MasjidOnline.Entity.Approval;

public class ApprovalSetting
{
    public required ApprovalSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
