using System.Collections.Generic;

namespace MasjidOnline.Business.Mapper.Payment;

public class PaymentTypeMapper
{
    private static readonly Dictionary<Business.Payment.Interface.Model.PaymentType, Entity.Payment.PaymentType> _toEntity = new()
    {
        { Business.Payment.Interface.Model.PaymentType.ManualBankTransfer, Entity.Payment.PaymentType.ManualBankTransfer },
    };

    private static readonly Dictionary<Entity.Payment.PaymentType, Business.Payment.Interface.Model.PaymentType> _toModel = new()
    {
        { Entity.Payment.PaymentType.ManualBankTransfer, Business.Payment.Interface.Model.PaymentType.ManualBankTransfer },
    };


    public Business.Payment.Interface.Model.PaymentType this[Entity.Payment.PaymentType entity]
    {
        get => _toModel[entity];
    }

    public Entity.Payment.PaymentType this[Business.Payment.Interface.Model.PaymentType model]
    {
        get => _toEntity[model];
    }
}
