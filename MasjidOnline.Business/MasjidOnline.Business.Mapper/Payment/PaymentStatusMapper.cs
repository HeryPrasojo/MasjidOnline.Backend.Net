using System.Collections.Generic;
using MasjidOnline.Business.Model.Payment.Payment;

namespace MasjidOnline.Business.Mapper.Payment;

public class PaymentStatusMapper
{
    private static readonly Dictionary<PaymentStatus, Entity.Payment.PaymentStatus> _toEntity = new()
    {
        { PaymentStatus.Cancel,         Entity.Payment.PaymentStatus.Cancel },
        { PaymentStatus.CancelRequest,  Entity.Payment.PaymentStatus.CancelRequest },
        { PaymentStatus.Expire,         Entity.Payment.PaymentStatus.Expire },
        { PaymentStatus.ExpireRequest,  Entity.Payment.PaymentStatus.ExpireRequest },
        { PaymentStatus.Fail,           Entity.Payment.PaymentStatus.Fail },
        { PaymentStatus.FailRequest,    Entity.Payment.PaymentStatus.FailRequest },
        { PaymentStatus.New,            Entity.Payment.PaymentStatus.New },
        { PaymentStatus.Success,        Entity.Payment.PaymentStatus.Success },
        { PaymentStatus.SuccessRequest, Entity.Payment.PaymentStatus.SuccessRequest },
        { PaymentStatus.Void,           Entity.Payment.PaymentStatus.Void },
        { PaymentStatus.VoidRequest,    Entity.Payment.PaymentStatus.VoidRequest },
    };

    private static readonly Dictionary<Entity.Payment.PaymentStatus, PaymentStatus> _toModel = new()
    {
        { Entity.Payment.PaymentStatus.Cancel,        PaymentStatus.Cancel },
        { Entity.Payment.PaymentStatus.CancelRequest, PaymentStatus.CancelRequest },
        { Entity.Payment.PaymentStatus.Expire,        PaymentStatus.Expire },
        { Entity.Payment.PaymentStatus.ExpireRequest, PaymentStatus.ExpireRequest },
        { Entity.Payment.PaymentStatus.Fail,          PaymentStatus.Fail },
        { Entity.Payment.PaymentStatus.FailRequest,   PaymentStatus.FailRequest },
        { Entity.Payment.PaymentStatus.New,           PaymentStatus.New },
        { Entity.Payment.PaymentStatus.Success,       PaymentStatus.Success },
        { Entity.Payment.PaymentStatus.SuccessRequest,PaymentStatus.SuccessRequest },
        { Entity.Payment.PaymentStatus.Void,          PaymentStatus.Void },
        { Entity.Payment.PaymentStatus.VoidRequest,   PaymentStatus.VoidRequest },
    };


    public PaymentStatus this[Entity.Payment.PaymentStatus entity]
    {
        get => _toModel[entity];
    }

    public Entity.Payment.PaymentStatus this[PaymentStatus model]
    {
        get => _toEntity[model];
    }
}
