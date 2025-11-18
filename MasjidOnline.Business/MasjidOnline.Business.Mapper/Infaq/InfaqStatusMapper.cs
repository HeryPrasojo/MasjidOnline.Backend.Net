namespace MasjidOnline.Business.Mapper.Infaq;

public class InfaqStatusMapper
{
    private static readonly Dictionary<Business.Infaq.Interface.Model.InfaqStatus, Entity.Infaq.InfaqStatus> _toEntity = new()
    {
        { Business.Infaq.Interface.Model.InfaqStatus.Cancel,         Entity.Infaq.InfaqStatus.Cancel },
        { Business.Infaq.Interface.Model.InfaqStatus.CancelRequest,  Entity.Infaq.InfaqStatus.CancelRequest },
        { Business.Infaq.Interface.Model.InfaqStatus.Expire,         Entity.Infaq.InfaqStatus.Expire },
        { Business.Infaq.Interface.Model.InfaqStatus.ExpireRequest,  Entity.Infaq.InfaqStatus.ExpireRequest },
        { Business.Infaq.Interface.Model.InfaqStatus.Fail,           Entity.Infaq.InfaqStatus.Fail },
        { Business.Infaq.Interface.Model.InfaqStatus.FailRequest,    Entity.Infaq.InfaqStatus.FailRequest },
        { Business.Infaq.Interface.Model.InfaqStatus.Invalid,        Entity.Infaq.InfaqStatus.Invalid },
        { Business.Infaq.Interface.Model.InfaqStatus.New,            Entity.Infaq.InfaqStatus.New },
        { Business.Infaq.Interface.Model.InfaqStatus.Success,        Entity.Infaq.InfaqStatus.Success },
        { Business.Infaq.Interface.Model.InfaqStatus.SuccessRequest, Entity.Infaq.InfaqStatus.SuccessRequest },
        { Business.Infaq.Interface.Model.InfaqStatus.Void,           Entity.Infaq.InfaqStatus.Void },
        { Business.Infaq.Interface.Model.InfaqStatus.VoidRequest,    Entity.Infaq.InfaqStatus.VoidRequest },
    };

    private static readonly Dictionary<Entity.Infaq.InfaqStatus, Business.Infaq.Interface.Model.InfaqStatus> _toModel = new()
    {
        { Entity.Infaq.InfaqStatus.Cancel,         Business.Infaq.Interface.Model.InfaqStatus.Cancel },
        { Entity.Infaq.InfaqStatus.CancelRequest,  Business.Infaq.Interface.Model.InfaqStatus.CancelRequest },
        { Entity.Infaq.InfaqStatus.Expire,         Business.Infaq.Interface.Model.InfaqStatus.Expire },
        { Entity.Infaq.InfaqStatus.ExpireRequest,  Business.Infaq.Interface.Model.InfaqStatus.ExpireRequest },
        { Entity.Infaq.InfaqStatus.Fail,           Business.Infaq.Interface.Model.InfaqStatus.Fail },
        { Entity.Infaq.InfaqStatus.FailRequest,    Business.Infaq.Interface.Model.InfaqStatus.FailRequest },
        { Entity.Infaq.InfaqStatus.Invalid,        Business.Infaq.Interface.Model.InfaqStatus.Invalid },
        { Entity.Infaq.InfaqStatus.New,            Business.Infaq.Interface.Model.InfaqStatus.New },
        { Entity.Infaq.InfaqStatus.Success,        Business.Infaq.Interface.Model.InfaqStatus.Success },
        { Entity.Infaq.InfaqStatus.SuccessRequest, Business.Infaq.Interface.Model.InfaqStatus.SuccessRequest },
        { Entity.Infaq.InfaqStatus.Void,           Business.Infaq.Interface.Model.InfaqStatus.Void },
        { Entity.Infaq.InfaqStatus.VoidRequest,    Business.Infaq.Interface.Model.InfaqStatus.VoidRequest },
    };


    public Entity.Infaq.InfaqStatus this[Business.Infaq.Interface.Model.InfaqStatus model]
    {
        get => _toEntity[model];
    }

    public Business.Infaq.Interface.Model.InfaqStatus this[Entity.Infaq.InfaqStatus entity]
    {
        get => _toModel[entity];
    }
}
