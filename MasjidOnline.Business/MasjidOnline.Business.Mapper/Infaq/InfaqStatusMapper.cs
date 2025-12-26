using System.Collections.Generic;
using MasjidOnline.Business.Model.Infaq;

namespace MasjidOnline.Business.Mapper.Infaq;

public class InfaqStatusMapper
{
    private static readonly Dictionary<InfaqStatus, Entity.Infaq.InfaqStatus> _toEntity = new()
    {
        { InfaqStatus.Cancel,         Entity.Infaq.InfaqStatus.Cancel },
        { InfaqStatus.CancelRequest,  Entity.Infaq.InfaqStatus.CancelRequest },
        { InfaqStatus.Expire,         Entity.Infaq.InfaqStatus.Expire },
        { InfaqStatus.ExpireRequest,  Entity.Infaq.InfaqStatus.ExpireRequest },
        { InfaqStatus.Fail,           Entity.Infaq.InfaqStatus.Fail },
        { InfaqStatus.FailRequest,    Entity.Infaq.InfaqStatus.FailRequest },
        { InfaqStatus.New,            Entity.Infaq.InfaqStatus.New },
        { InfaqStatus.Success,        Entity.Infaq.InfaqStatus.Success },
        { InfaqStatus.SuccessRequest, Entity.Infaq.InfaqStatus.SuccessRequest },
        { InfaqStatus.Void,           Entity.Infaq.InfaqStatus.Void },
        { InfaqStatus.VoidRequest,    Entity.Infaq.InfaqStatus.VoidRequest },
    };

    private static readonly Dictionary<Entity.Infaq.InfaqStatus, InfaqStatus> _toModel = new()
    {
        { Entity.Infaq.InfaqStatus.Cancel,         InfaqStatus.Cancel },
        { Entity.Infaq.InfaqStatus.CancelRequest,  InfaqStatus.CancelRequest },
        { Entity.Infaq.InfaqStatus.Expire,         InfaqStatus.Expire },
        { Entity.Infaq.InfaqStatus.ExpireRequest,  InfaqStatus.ExpireRequest },
        { Entity.Infaq.InfaqStatus.Fail,           InfaqStatus.Fail },
        { Entity.Infaq.InfaqStatus.FailRequest,    InfaqStatus.FailRequest },
        { Entity.Infaq.InfaqStatus.New,            InfaqStatus.New },
        { Entity.Infaq.InfaqStatus.Success,        InfaqStatus.Success },
        { Entity.Infaq.InfaqStatus.SuccessRequest, InfaqStatus.SuccessRequest },
        { Entity.Infaq.InfaqStatus.Void,           InfaqStatus.Void },
        { Entity.Infaq.InfaqStatus.VoidRequest,    InfaqStatus.VoidRequest },
    };


    public Entity.Infaq.InfaqStatus this[InfaqStatus model]
    {
        get => _toEntity[model];
    }

    public InfaqStatus this[Entity.Infaq.InfaqStatus entity]
    {
        get => _toModel[entity];
    }
}
