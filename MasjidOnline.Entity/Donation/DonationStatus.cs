namespace MasjidOnline.Entity.Donation;

public enum DonationStatus
{
    New = 2,

    FailRequest = 4,
    Fail = 6,

    SuccessRequest = 8,
    Success = 10,

    RefundRequest = 12,
    Refund = 14,
}

