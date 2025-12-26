using System.Collections.Generic;
using MasjidOnline.Business.Model.Payment;

namespace MasjidOnline.Business.Mapper.Payment;

public class PaymentTypeMapper
{
    private static readonly Dictionary<PaymentType, Entity.Payment.PaymentType> _toEntity = new()
    {
        { PaymentType.ManualBankTransfer, Entity.Payment.PaymentType.ManualBankTransfer },
    };

    private static readonly Dictionary<Entity.Payment.PaymentType, PaymentType> _toModel = new()
    {
        { Entity.Payment.PaymentType.ManualBankTransfer, PaymentType.ManualBankTransfer },
    };


    public PaymentType this[Entity.Payment.PaymentType entity]
    {
        get => _toModel[entity];
    }

    public Entity.Payment.PaymentType this[PaymentType model]
    {
        get => _toEntity[model];
    }
}
