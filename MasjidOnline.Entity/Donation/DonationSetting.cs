namespace MasjidOnline.Entity.Donation;

public class DonationSetting
{
    public required DonationSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}

