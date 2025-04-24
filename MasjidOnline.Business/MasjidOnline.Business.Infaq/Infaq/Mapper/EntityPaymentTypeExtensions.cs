using MasjidOnline.Entity.Payment;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Infaq.Mapper;

public static class EntityPaymentTypeExtensions
{
    public static Payment.Interface.Model.PaymentType ToModel(this PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.Cash
                => Payment.Interface.Model.PaymentType.Cash,

            PaymentType.ManualBankTransfer
                => Payment.Interface.Model.PaymentType.ManualBankTransfer,

            _ => throw new ErrorException(nameof(paymentType)),
        };
    }
}
