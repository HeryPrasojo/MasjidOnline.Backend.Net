using MasjidOnline.Entity.Payment;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class ModelPaymentTypeExtensions
{
    public static PaymentType ToEntity(this Payment.Interface.Model.PaymentType paymentType)
    {
        return paymentType switch
        {
            Payment.Interface.Model.PaymentType.Cash
                => PaymentType.ManualCash,

            Payment.Interface.Model.PaymentType.ManualBankTransfer
                => PaymentType.ManualBankTransfer,

            _ => throw new ErrorException(nameof(paymentType)),
        };
    }
}
