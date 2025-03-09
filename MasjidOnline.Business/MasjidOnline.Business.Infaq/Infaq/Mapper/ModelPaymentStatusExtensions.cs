using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class ModelPaymentStatusExtensions
{
    public static Entity.Infaq.PaymentStatus ToEntity(this Interface.Model.Payment.PaymentStatus paymentStatus)
    {
        return paymentStatus switch
        {
            Interface.Model.Payment.PaymentStatus.Cancel
                => Entity.Infaq.PaymentStatus.Cancel,

            Interface.Model.Payment.PaymentStatus.CancelRequest
                => Entity.Infaq.PaymentStatus.CancelRequest,

            Interface.Model.Payment.PaymentStatus.Expire
                => Entity.Infaq.PaymentStatus.Expire,

            Interface.Model.Payment.PaymentStatus.ExpireRequest
                => Entity.Infaq.PaymentStatus.ExpireRequest,

            Interface.Model.Payment.PaymentStatus.Fail
                => Entity.Infaq.PaymentStatus.Fail,

            Interface.Model.Payment.PaymentStatus.FailRequest
                => Entity.Infaq.PaymentStatus.FailRequest,

            Interface.Model.Payment.PaymentStatus.Pending
                => Entity.Infaq.PaymentStatus.New,

            Interface.Model.Payment.PaymentStatus.Success
                => Entity.Infaq.PaymentStatus.Success,

            Interface.Model.Payment.PaymentStatus.SuccessRequest
                => Entity.Infaq.PaymentStatus.SuccessRequest,

            Interface.Model.Payment.PaymentStatus.Void
                => Entity.Infaq.PaymentStatus.Void,

            Interface.Model.Payment.PaymentStatus.VoidRequest
                => Entity.Infaq.PaymentStatus.VoidRequest,

            _ => throw new ErrorException(nameof(paymentStatus)),
        };
    }
}
