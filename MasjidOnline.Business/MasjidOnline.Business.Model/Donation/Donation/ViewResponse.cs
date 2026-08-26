using MasjidOnline.Business.Model.Payment.Payment;

namespace MasjidOnline.Business.Model.Donation.Donation;

public class ViewResponse
{
    public required string DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required string Amount { get; set; }


    public required PaymentType PaymentType { get; set; }
    public required string PaymentTypeText { get; set; }

    public required DonationStatus Status { get; set; }
    public required string StatusText { get; set; }

    public string? RequestBy { get; set; }
    public string? RequestDateTime { get; set; }
}

