using System.Collections.Generic;
using MasjidOnline.Business.Model.User.UserPreference;

namespace MasjidOnline.Business.Mapper.User;

public class UserPreferenceApplicationCultureMapper
{
    private static readonly Dictionary<Entity.User.UserPreferenceApplicationCulture, UserPreferenceApplicationCulture> _toModel = new()
    {
        { Entity.User.UserPreferenceApplicationCulture.English, UserPreferenceApplicationCulture.English },
    };

    private static readonly Dictionary<UserPreferenceApplicationCulture, Entity.User.UserPreferenceApplicationCulture> _toEntity = new()
    {
        { UserPreferenceApplicationCulture.English, Entity.User.UserPreferenceApplicationCulture.English },
    };


    public Entity.User.UserPreferenceApplicationCulture this[UserPreferenceApplicationCulture cultureInfo]
    {
        get => _toEntity[cultureInfo];
    }

    public UserPreferenceApplicationCulture this[Entity.User.UserPreferenceApplicationCulture userPreferenceApplicationCulture]
    {
        get => _toModel[userPreferenceApplicationCulture];
    }
}
