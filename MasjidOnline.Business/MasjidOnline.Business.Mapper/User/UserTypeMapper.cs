using System.Collections.Generic;
using MasjidOnline.Business.Model.User.User;

namespace MasjidOnline.Business.Mapper.User;

public class UserTypeMapper
{
    private static readonly Dictionary<UserType, Entity.User.UserType> _toEntity = new()
    {
        { UserType.Anonymous, Entity.User.UserType.Anonymous },
        { UserType.External,  Entity.User.UserType.External },
        { UserType.Internal,  Entity.User.UserType.Internal },
        { UserType.System,    Entity.User.UserType.System },
    };

    private static readonly Dictionary<Entity.User.UserType, UserType> _toModel = new()
    {
        { Entity.User.UserType.Anonymous, UserType.Anonymous },
        { Entity.User.UserType.External, UserType.External },
        { Entity.User.UserType.Internal, UserType.Internal },
        { Entity.User.UserType.System, UserType.System },
    };


    public UserType this[Entity.User.UserType entity]
    {
        get => _toModel[entity];
    }

    public Entity.User.UserType this[UserType model]
    {
        get => _toEntity[model];
    }
}
