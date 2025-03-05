using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class EntityPaymentTypeExtensions
{
    public static Interface.Model.Payment.PaymentType ToModel(this Entity.Infaq.PaymentType paymentType)
    {
        return paymentType switch
        {
            Entity.Infaq.PaymentType.Cash
                => Interface.Model.Payment.PaymentType.Cash,

            Entity.Infaq.PaymentType.ManualBankTransfer
                => Interface.Model.Payment.PaymentType.ManualBankTransfer,

            _ => throw new ErrorException(nameof(paymentType)),
        };
    }
}
