using System.Collections.Generic;
using MasjidOnline.Business.Model.User.UserData;

namespace MasjidOnline.Business.Mapper.User;

public class UserPreferenceApplicationCultureMapper
{
    private static readonly Dictionary<Entity.User.ApplicationCulture, ApplicationCulture> _toModel = new()
    {
        { Entity.User.ApplicationCulture.English, ApplicationCulture.English },
    };

    private static readonly Dictionary<ApplicationCulture, Entity.User.ApplicationCulture> _toEntity = new()
    {
        { ApplicationCulture.English, Entity.User.ApplicationCulture.English },
    };


    public Entity.User.ApplicationCulture this[ApplicationCulture cultureInfo]
    {
        get => _toEntity[cultureInfo];
    }

    public ApplicationCulture this[Entity.User.ApplicationCulture applicationCulture]
    {
        get => _toModel[applicationCulture];
    }
}
