namespace MasjidOnline.Business.Mapper.User;

public class UserTypeMapper
{
    private static readonly Dictionary<Business.User.Interface.Model.User.UserType, Entity.User.UserType> _toEntity = new()
    {
        { Business.User.Interface.Model.User.UserType.Anonymous, Entity.User.UserType.Anonymous },
        { Business.User.Interface.Model.User.UserType.External,  Entity.User.UserType.External },
        { Business.User.Interface.Model.User.UserType.Internal,  Entity.User.UserType.Internal },
        { Business.User.Interface.Model.User.UserType.System,    Entity.User.UserType.System },
    };

    private static readonly Dictionary<Entity.User.UserType, Business.User.Interface.Model.User.UserType> _toModel = new()
    {
        { Entity.User.UserType.Anonymous, Business.User.Interface.Model.User.UserType.Anonymous },
        { Entity.User.UserType.External, Business.User.Interface.Model.User.UserType.External },
        { Entity.User.UserType.Internal, Business.User.Interface.Model.User.UserType.Internal },
        { Entity.User.UserType.System, Business.User.Interface.Model.User.UserType.System },
    };


    public Business.User.Interface.Model.User.UserType this[Entity.User.UserType entity]
    {
        get => _toModel[entity];
    }

    public Entity.User.UserType this[Business.User.Interface.Model.User.UserType model]
    {
        get => _toEntity[model];
    }
}
