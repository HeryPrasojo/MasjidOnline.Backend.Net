namespace MasjidOnline.Business.Infaq.Interface.Model.Payment;

// hack move to MasjidOnline.Business.Interface.Model
public enum PaymentStatus
{
    Invalid = 0,
    Pending = 11,
    CancelRequest = 22,
    Cancel = 33,
    FailRequest = 44,
    Fail = 55,
    ExpireRequest = 66,
    Expire = 77,
    SuccessRequest = 83,
    Success = 88,
    VoidRequest = 95,
    Void = 99,
}
