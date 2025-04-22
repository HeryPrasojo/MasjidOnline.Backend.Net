using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class EntityPaymentTypeExtensions
{
    public static Payment.Interface.Model.PaymentType ToModel(this Entity.Infaq.PaymentType paymentType)
    {
        return paymentType switch
        {
            Entity.Infaq.PaymentType.Cash
                => Payment.Interface.Model.PaymentType.Cash,

            Entity.Infaq.PaymentType.ManualBankTransfer
                => Payment.Interface.Model.PaymentType.ManualBankTransfer,

            _ => throw new ErrorException(nameof(paymentType)),
        };
    }
}
