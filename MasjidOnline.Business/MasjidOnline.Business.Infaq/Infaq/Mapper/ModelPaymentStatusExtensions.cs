using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class ModelPaymentStatusExtensions
{
    public static InfaqStatus ToEntity(this Payment.Interface.Model.PaymentStatus paymentStatus)
    {
        return paymentStatus switch
        {
            Payment.Interface.Model.PaymentStatus.Cancel
                => InfaqStatus.Cancel,

            Payment.Interface.Model.PaymentStatus.CancelRequest
                => InfaqStatus.CancelRequest,

            Payment.Interface.Model.PaymentStatus.Expire
                => InfaqStatus.Expire,

            Payment.Interface.Model.PaymentStatus.ExpireRequest
                => InfaqStatus.ExpireRequest,

            Payment.Interface.Model.PaymentStatus.Fail
                => InfaqStatus.Fail,

            Payment.Interface.Model.PaymentStatus.FailRequest
                => InfaqStatus.FailRequest,

            Payment.Interface.Model.PaymentStatus.Pending
                => InfaqStatus.New,

            Payment.Interface.Model.PaymentStatus.Success
                => InfaqStatus.Success,

            Payment.Interface.Model.PaymentStatus.SuccessRequest
                => InfaqStatus.SuccessRequest,

            Payment.Interface.Model.PaymentStatus.Void
                => InfaqStatus.Void,

            Payment.Interface.Model.PaymentStatus.VoidRequest
                => InfaqStatus.VoidRequest,

            _ => throw new ErrorException(nameof(paymentStatus)),
        };
    }
}
