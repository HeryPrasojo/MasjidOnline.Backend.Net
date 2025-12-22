using System.Globalization;

namespace MasjidOnline.Business.Mapper.Session;

public class UserPreferenceApplicationCultureMapper
{
    private static readonly Dictionary<Entity.User.UserPreferenceApplicationCulture, CultureInfo> _toCultureInfo = new()
    {
        { Entity.User.UserPreferenceApplicationCulture.English, Service.Localization.Interface.Constant.English.CultureInfo },
        { default,                                              Service.Localization.Interface.Constant.Indonesian.CultureInfo },
    };

    private static readonly Dictionary<CultureInfo, Entity.User.UserPreferenceApplicationCulture> _toEntity = new()
    {
        { Service.Localization.Interface.Constant.English.CultureInfo, Entity.User.UserPreferenceApplicationCulture.English },
    };


    public CultureInfo this[Entity.User.UserPreferenceApplicationCulture userPreferenceApplicationCulture]
    {
        get => _toCultureInfo[userPreferenceApplicationCulture];
    }

    public Entity.User.UserPreferenceApplicationCulture this[CultureInfo cultureInfo]
    {
        get => _toEntity[cultureInfo];
    }
}
