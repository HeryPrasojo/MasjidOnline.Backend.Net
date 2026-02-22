using System.Collections.Generic;

namespace MasjidOnline.Business.Mapper.Payment;

public class PaymentStatusMapper
{
    private static readonly Dictionary<Model.Payment.PaymentStatus, Entity.Payment.PaymentStatus> _toEntity = new()
    {
        { Model.Payment.PaymentStatus.Cancel,         Entity.Payment.PaymentStatus.Cancel },
        { Model.Payment.PaymentStatus.CancelRequest,  Entity.Payment.PaymentStatus.CancelRequest },
        { Model.Payment.PaymentStatus.Expire,         Entity.Payment.PaymentStatus.Expire },
        { Model.Payment.PaymentStatus.ExpireRequest,  Entity.Payment.PaymentStatus.ExpireRequest },
        { Model.Payment.PaymentStatus.Fail,           Entity.Payment.PaymentStatus.Fail },
        { Model.Payment.PaymentStatus.FailRequest,    Entity.Payment.PaymentStatus.FailRequest },
        { Model.Payment.PaymentStatus.New,            Entity.Payment.PaymentStatus.New },
        { Model.Payment.PaymentStatus.Success,        Entity.Payment.PaymentStatus.Success },
        { Model.Payment.PaymentStatus.SuccessRequest, Entity.Payment.PaymentStatus.SuccessRequest },
        { Model.Payment.PaymentStatus.Void,           Entity.Payment.PaymentStatus.Void },
        { Model.Payment.PaymentStatus.VoidRequest,    Entity.Payment.PaymentStatus.VoidRequest },
    };

    private static readonly Dictionary<Entity.Payment.PaymentStatus, Model.Payment.PaymentStatus> _toModel = new()
    {
        { Entity.Payment.PaymentStatus.Cancel,        Model.Payment.PaymentStatus.Cancel },
        { Entity.Payment.PaymentStatus.CancelRequest, Model.Payment.PaymentStatus.CancelRequest },
        { Entity.Payment.PaymentStatus.Expire,        Model.Payment.PaymentStatus.Expire },
        { Entity.Payment.PaymentStatus.ExpireRequest, Model.Payment.PaymentStatus.ExpireRequest },
        { Entity.Payment.PaymentStatus.Fail,          Model.Payment.PaymentStatus.Fail },
        { Entity.Payment.PaymentStatus.FailRequest,   Model.Payment.PaymentStatus.FailRequest },
        { Entity.Payment.PaymentStatus.New,           Model.Payment.PaymentStatus.New },
        { Entity.Payment.PaymentStatus.Success,       Model.Payment.PaymentStatus.Success },
        { Entity.Payment.PaymentStatus.SuccessRequest,Model.Payment.PaymentStatus.SuccessRequest },
        { Entity.Payment.PaymentStatus.Void,          Model.Payment.PaymentStatus.Void },
        { Entity.Payment.PaymentStatus.VoidRequest,   Model.Payment.PaymentStatus.VoidRequest },
    };


    public Model.Payment.PaymentStatus this[Entity.Payment.PaymentStatus entity]
    {
        get => _toModel[entity];
    }

    public Entity.Payment.PaymentStatus this[Model.Payment.PaymentStatus model]
    {
        get => _toEntity[model];
    }
}
