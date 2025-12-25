
using System.Collections.Generic;

namespace MasjidOnline.Business.Mapper.Event;

public class UserLoginClientMapper
{
    private static readonly Dictionary<Business.Event.Interface.Model.UserLoginClient, Entity.Event.UserLoginClient> _toEntities = new()
    {
        { Business.Event.Interface.Model.UserLoginClient.Android, Entity.Event.UserLoginClient.Android },
        { Business.Event.Interface.Model.UserLoginClient.Web,     Entity.Event.UserLoginClient.Web },
    };

    public Entity.Event.UserLoginClient this[Business.Event.Interface.Model.UserLoginClient model]
    {
        get => _toEntities[model];
    }
}
