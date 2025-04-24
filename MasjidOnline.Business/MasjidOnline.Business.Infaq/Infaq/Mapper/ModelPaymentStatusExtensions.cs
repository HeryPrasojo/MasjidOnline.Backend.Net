using MasjidOnline.Entity.Payment;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class ModelPaymentStatusExtensions
{
    public static PaymentStatus ToEntity(this Payment.Interface.Model.PaymentStatus paymentStatus)
    {
        return paymentStatus switch
        {
            Payment.Interface.Model.PaymentStatus.Cancel
                => PaymentStatus.Cancel,

            Payment.Interface.Model.PaymentStatus.CancelRequest
                => PaymentStatus.CancelRequest,

            Payment.Interface.Model.PaymentStatus.Expire
                => PaymentStatus.Expire,

            Payment.Interface.Model.PaymentStatus.ExpireRequest
                => PaymentStatus.ExpireRequest,

            Payment.Interface.Model.PaymentStatus.Fail
                => PaymentStatus.Fail,

            Payment.Interface.Model.PaymentStatus.FailRequest
                => PaymentStatus.FailRequest,

            Payment.Interface.Model.PaymentStatus.Pending
                => PaymentStatus.New,

            Payment.Interface.Model.PaymentStatus.Success
                => PaymentStatus.Success,

            Payment.Interface.Model.PaymentStatus.SuccessRequest
                => PaymentStatus.SuccessRequest,

            Payment.Interface.Model.PaymentStatus.Void
                => PaymentStatus.Void,

            Payment.Interface.Model.PaymentStatus.VoidRequest
                => PaymentStatus.VoidRequest,

            _ => throw new ErrorException(nameof(paymentStatus)),
        };
    }
}
