using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class ModelPaymentTypeExtensions
{
    public static Entity.Infaq.PaymentType ToEntity(this Interface.Model.Payment.PaymentType paymentType)
    {
        return paymentType switch
        {
            Interface.Model.Payment.PaymentType.Cash
                => Entity.Infaq.PaymentType.Cash,

            Interface.Model.Payment.PaymentType.ManualBankTransfer
                => Entity.Infaq.PaymentType.ManualBankTransfer,

            _ => throw new ErrorException(nameof(paymentType)),
        };
    }
}
