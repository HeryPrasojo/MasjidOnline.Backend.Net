using System.Collections.Generic;
using MasjidOnline.Business.Model.User.Internal;

namespace MasjidOnline.Business.Mapper.User;

public class InternalUserStatusMapper
{
    private static readonly Dictionary<InternalUserStatus, Entity.User.InternalUserStatus> _toEntity = new()
    {
        { InternalUserStatus.Approve, Entity.User.InternalUserStatus.Approve },
        { InternalUserStatus.Cancel,  Entity.User.InternalUserStatus.Cancel },
        { InternalUserStatus.New,     Entity.User.InternalUserStatus.New },
        { InternalUserStatus.Reject,  Entity.User.InternalUserStatus.Reject },
    };

    private static readonly Dictionary<Entity.User.InternalUserStatus, InternalUserStatus> _toModel = new()
    {
        { Entity.User.InternalUserStatus.Approve, InternalUserStatus.Approve },
        { Entity.User.InternalUserStatus.Cancel,  InternalUserStatus.Cancel },
        { Entity.User.InternalUserStatus.New,     InternalUserStatus.New },
        { Entity.User.InternalUserStatus.Reject,  InternalUserStatus.Reject },
    };


    public InternalUserStatus this[Entity.User.InternalUserStatus entity]
    {
        get => _toModel[entity];
    }

    public Entity.User.InternalUserStatus this[InternalUserStatus model]
    {
        get => _toEntity[model];
    }
}
