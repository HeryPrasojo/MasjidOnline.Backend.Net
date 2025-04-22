using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class ModelPaymentTypeExtensions
{
    public static Entity.Infaq.PaymentType ToEntity(this Payment.Interface.Model.PaymentType paymentType)
    {
        return paymentType switch
        {
            Payment.Interface.Model.PaymentType.Cash
                => Entity.Infaq.PaymentType.Cash,

            Payment.Interface.Model.PaymentType.ManualBankTransfer
                => Entity.Infaq.PaymentType.ManualBankTransfer,

            _ => throw new ErrorException(nameof(paymentType)),
        };
    }
}
