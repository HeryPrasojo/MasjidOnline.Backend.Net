using MasjidOnline.Entity.Payment;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class EntityPaymentStatusExtensions
{
    public static string ToLocale(this PaymentStatus paymentStatus)
    {
        return paymentStatus switch
        {
            PaymentStatus.Cancel => "Cancel",

            PaymentStatus.CancelRequest => "CancelRequest",

            PaymentStatus.Expire => "Expire",

            PaymentStatus.ExpireRequest => "ExpireRequest",

            PaymentStatus.Fail => "Fail",

            PaymentStatus.FailRequest => "FailRequest",

            PaymentStatus.New => "Pending",

            PaymentStatus.Success => "Success",

            PaymentStatus.SuccessRequest => "SuccessRequest",

            PaymentStatus.Void => "Void",

            PaymentStatus.VoidRequest => "VoidRequest",

            _ => throw new ErrorException(nameof(paymentStatus)),
        };
    }
}
