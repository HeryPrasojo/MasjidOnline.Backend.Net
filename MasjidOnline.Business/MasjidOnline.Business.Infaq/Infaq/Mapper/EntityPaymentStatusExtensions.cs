using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class EntityPaymentStatusExtensions
{
    public static Payment.Interface.Model.PaymentStatus ToModel(this Entity.Infaq.PaymentStatus paymentStatus)
    {
        return paymentStatus switch
        {
            Entity.Infaq.PaymentStatus.Cancel
                => Payment.Interface.Model.PaymentStatus.Cancel,

            Entity.Infaq.PaymentStatus.CancelRequest
                => Payment.Interface.Model.PaymentStatus.CancelRequest,

            Entity.Infaq.PaymentStatus.Expire
                => Payment.Interface.Model.PaymentStatus.Expire,

            Entity.Infaq.PaymentStatus.ExpireRequest
                => Payment.Interface.Model.PaymentStatus.ExpireRequest,

            Entity.Infaq.PaymentStatus.Fail
                => Payment.Interface.Model.PaymentStatus.Fail,

            Entity.Infaq.PaymentStatus.FailRequest
                => Payment.Interface.Model.PaymentStatus.FailRequest,

            Entity.Infaq.PaymentStatus.New
                => Payment.Interface.Model.PaymentStatus.Pending,

            Entity.Infaq.PaymentStatus.Success
                => Payment.Interface.Model.PaymentStatus.Success,

            Entity.Infaq.PaymentStatus.SuccessRequest
                => Payment.Interface.Model.PaymentStatus.SuccessRequest,

            Entity.Infaq.PaymentStatus.Void
                => Payment.Interface.Model.PaymentStatus.Void,

            Entity.Infaq.PaymentStatus.VoidRequest
                => Payment.Interface.Model.PaymentStatus.VoidRequest,

            _ => throw new ErrorException(nameof(paymentStatus)),
        };
    }
}
