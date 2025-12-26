
using System.Collections.Generic;
using MasjidOnline.Business.Model.Event;

namespace MasjidOnline.Business.Mapper.Event;

public class UserLoginClientMapper
{
    private static readonly Dictionary<UserLoginClient, Entity.Event.UserLoginClient> _toEntities = new()
    {
        { UserLoginClient.Android, Entity.Event.UserLoginClient.Android },
        { UserLoginClient.Web,     Entity.Event.UserLoginClient.Web },
    };

    public Entity.Event.UserLoginClient this[UserLoginClient model]
    {
        get => _toEntities[model];
    }
}
