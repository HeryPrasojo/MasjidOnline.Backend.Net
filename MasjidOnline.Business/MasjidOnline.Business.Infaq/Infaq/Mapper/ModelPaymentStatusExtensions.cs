using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class ModelPaymentStatusExtensions
{
    public static Entity.Infaq.PaymentStatus MapEntity(this Interface.Model.Payment.PaymentStatus paymentStatus)
    {
        return paymentStatus switch
        {
            Business.Infaq.Interface.Model.Payment.PaymentStatus.Cancel
                => Entity.Infaq.PaymentStatus.Cancel,

            Business.Infaq.Interface.Model.Payment.PaymentStatus.CancelRequest
                => Entity.Infaq.PaymentStatus.CancelRequest,

            Business.Infaq.Interface.Model.Payment.PaymentStatus.Expire
                => Entity.Infaq.PaymentStatus.Expire,

            Business.Infaq.Interface.Model.Payment.PaymentStatus.ExpireRequest
                => Entity.Infaq.PaymentStatus.ExpireRequest,

            Business.Infaq.Interface.Model.Payment.PaymentStatus.Fail
                => Entity.Infaq.PaymentStatus.Fail,

            Business.Infaq.Interface.Model.Payment.PaymentStatus.FailRequest
                => Entity.Infaq.PaymentStatus.FailRequest,

            Business.Infaq.Interface.Model.Payment.PaymentStatus.Pending
                => Entity.Infaq.PaymentStatus.Pending,

            Business.Infaq.Interface.Model.Payment.PaymentStatus.Success
                => Entity.Infaq.PaymentStatus.Success,

            Business.Infaq.Interface.Model.Payment.PaymentStatus.SuccessRequest
                => Entity.Infaq.PaymentStatus.SuccessRequest,

            Business.Infaq.Interface.Model.Payment.PaymentStatus.Void
                => Entity.Infaq.PaymentStatus.Void,

            Business.Infaq.Interface.Model.Payment.PaymentStatus.VoidRequest
                => Entity.Infaq.PaymentStatus.VoidRequest,

            _ => throw new ErrorException(nameof(paymentStatus)),
        };
    }
}
