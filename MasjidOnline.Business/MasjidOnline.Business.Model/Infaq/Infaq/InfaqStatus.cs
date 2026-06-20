namespace MasjidOnline.Business.Model.Infaq.Infaq;

public enum InfaqStatus
{
    New = 2,


    CancelRequest = 4,
    Cancel = 6,

    ExpireRequest = 8,
    Expire = 10,

    FailRequest = 12,
    Fail = 14,

    RejectRequest = 16,
    Reject = 18,


    SuccessRequest = 20,
    Success = 22,


    RefundRequest = 24,
    Refund = 26,
}
