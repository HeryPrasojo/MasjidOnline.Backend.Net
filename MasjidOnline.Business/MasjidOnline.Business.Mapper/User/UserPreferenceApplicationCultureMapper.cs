using System.Collections.Generic;

namespace MasjidOnline.Business.Mapper.User;

public class UserPreferenceApplicationCultureMapper
{
    private static readonly Dictionary<Entity.User.UserPreferenceApplicationCulture, Model.User.UserPreference.UserPreferenceApplicationCulture> _toModel = new()
    {
        { Entity.User.UserPreferenceApplicationCulture.English, Model.User.UserPreference.UserPreferenceApplicationCulture.English },
    };

    private static readonly Dictionary<Model.User.UserPreference.UserPreferenceApplicationCulture, Entity.User.UserPreferenceApplicationCulture> _toEntity = new()
    {
        { Model.User.UserPreference.UserPreferenceApplicationCulture.English, Entity.User.UserPreferenceApplicationCulture.English },
    };


    public Entity.User.UserPreferenceApplicationCulture this[Model.User.UserPreference.UserPreferenceApplicationCulture cultureInfo]
    {
        get => _toEntity[cultureInfo];
    }

    public Model.User.UserPreference.UserPreferenceApplicationCulture this[Entity.User.UserPreferenceApplicationCulture userPreferenceApplicationCulture]
    {
        get => _toModel[userPreferenceApplicationCulture];
    }
}
