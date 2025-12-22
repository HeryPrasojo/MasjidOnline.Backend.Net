namespace MasjidOnline.Business.Mapper.User;

public class UserPreferenceApplicationCultureMapper
{
    private static readonly Dictionary<Entity.User.UserPreferenceApplicationCulture, Business.User.Interface.Model.UserPreference.UserPreferenceApplicationCulture> _toModel = new()
    {
        { Entity.User.UserPreferenceApplicationCulture.English, Business.User.Interface.Model.UserPreference.UserPreferenceApplicationCulture.English },
    };

    private static readonly Dictionary<Business.User.Interface.Model.UserPreference.UserPreferenceApplicationCulture, Entity.User.UserPreferenceApplicationCulture> _toEntity = new()
    {
        { Business.User.Interface.Model.UserPreference.UserPreferenceApplicationCulture.English, Entity.User.UserPreferenceApplicationCulture.English },
    };


    public Entity.User.UserPreferenceApplicationCulture this[Business.User.Interface.Model.UserPreference.UserPreferenceApplicationCulture cultureInfo]
    {
        get => _toEntity[cultureInfo];
    }

    public Business.User.Interface.Model.UserPreference.UserPreferenceApplicationCulture this[Entity.User.UserPreferenceApplicationCulture userPreferenceApplicationCulture]
    {
        get => _toModel[userPreferenceApplicationCulture];
    }
}
