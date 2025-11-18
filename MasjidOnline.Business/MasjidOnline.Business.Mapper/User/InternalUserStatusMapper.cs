namespace MasjidOnline.Business.Mapper.User;

public class InternalUserStatusMapper
{
    private static readonly Dictionary<Business.User.Interface.Model.Internal.InternalUserStatus, Entity.User.InternalUserStatus> _toEntity = new()
    {
        { Business.User.Interface.Model.Internal.InternalUserStatus.Approve, Entity.User.InternalUserStatus.Approve },
        { Business.User.Interface.Model.Internal.InternalUserStatus.Cancel,  Entity.User.InternalUserStatus.Cancel },
        { Business.User.Interface.Model.Internal.InternalUserStatus.New,     Entity.User.InternalUserStatus.New },
        { Business.User.Interface.Model.Internal.InternalUserStatus.Reject,  Entity.User.InternalUserStatus.Reject },
    };

    private static readonly Dictionary<Entity.User.InternalUserStatus, Business.User.Interface.Model.Internal.InternalUserStatus> _toModel = new()
    {
        { Entity.User.InternalUserStatus.Approve, Business.User.Interface.Model.Internal.InternalUserStatus.Approve },
        { Entity.User.InternalUserStatus.Cancel,  Business.User.Interface.Model.Internal.InternalUserStatus.Cancel },
        { Entity.User.InternalUserStatus.New,     Business.User.Interface.Model.Internal.InternalUserStatus.New },
        { Entity.User.InternalUserStatus.Reject,  Business.User.Interface.Model.Internal.InternalUserStatus.Reject },
    };


    public Business.User.Interface.Model.Internal.InternalUserStatus this[Entity.User.InternalUserStatus entity]
    {
        get => _toModel[entity];
    }

    public Entity.User.InternalUserStatus this[Business.User.Interface.Model.Internal.InternalUserStatus model]
    {
        get => _toEntity[model];
    }
}
