namespace MasjidOnline.Business.Infaq.Interface.Model.Payment;

// hack move to MasjidOnline.Business.Interface.Model
public enum PaymentStatus
{
    None = 0,
    Pending = 11,
    Canceled = 31,
    Failed = 51,
    Expired = 71,
    Success = 99,
}
