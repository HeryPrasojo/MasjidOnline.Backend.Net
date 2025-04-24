using MasjidOnline.Entity.Payment;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class EntityPaymentStatusExtensions
{
    public static Payment.Interface.Model.PaymentStatus ToModel(this PaymentStatus paymentStatus)
    {
        return paymentStatus switch
        {
            PaymentStatus.Cancel
                => Payment.Interface.Model.PaymentStatus.Cancel,

            PaymentStatus.CancelRequest
                => Payment.Interface.Model.PaymentStatus.CancelRequest,

            PaymentStatus.Expire
                => Payment.Interface.Model.PaymentStatus.Expire,

            PaymentStatus.ExpireRequest
                => Payment.Interface.Model.PaymentStatus.ExpireRequest,

            PaymentStatus.Fail
                => Payment.Interface.Model.PaymentStatus.Fail,

            PaymentStatus.FailRequest
                => Payment.Interface.Model.PaymentStatus.FailRequest,

            PaymentStatus.New
                => Payment.Interface.Model.PaymentStatus.Pending,

            PaymentStatus.Success
                => Payment.Interface.Model.PaymentStatus.Success,

            PaymentStatus.SuccessRequest
                => Payment.Interface.Model.PaymentStatus.SuccessRequest,

            PaymentStatus.Void
                => Payment.Interface.Model.PaymentStatus.Void,

            PaymentStatus.VoidRequest
                => Payment.Interface.Model.PaymentStatus.VoidRequest,

            _ => throw new ErrorException(nameof(paymentStatus)),
        };
    }
}
