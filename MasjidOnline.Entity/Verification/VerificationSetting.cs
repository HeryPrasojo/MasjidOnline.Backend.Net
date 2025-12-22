namespace MasjidOnline.Entity.Verification;

public class VerificationSetting
{
    public required VerificationSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
