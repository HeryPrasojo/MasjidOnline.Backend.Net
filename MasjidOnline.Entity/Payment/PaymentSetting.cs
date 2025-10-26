namespace MasjidOnline.Entity.Payment;

public class PaymentSetting
{
    public required PaymentSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
