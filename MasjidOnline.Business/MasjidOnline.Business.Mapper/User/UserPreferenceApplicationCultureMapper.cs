using System.Globalization;

namespace MasjidOnline.Business.Mapper.User;

public class UserPreferenceApplicationCultureMapper
{
    private static readonly Dictionary<Entity.User.UserPreferenceApplicationCulture, CultureInfo> _toCultureInfo = new()
        {
            { Entity.User.UserPreferenceApplicationCulture.English, Service.Localization.Interface.Model.Constant.CultureInfoEnglish },
            { Entity.User.UserPreferenceApplicationCulture.Invalid, Service.Localization.Interface.Model.Constant.CultureInfoEnglish },
        };

    private static readonly Dictionary<CultureInfo, Entity.User.UserPreferenceApplicationCulture> _toEntity = new()
        {
            { Service.Localization.Interface.Model.Constant.CultureInfoEnglish, Entity.User.UserPreferenceApplicationCulture.English },
        };


    public Entity.User.UserPreferenceApplicationCulture this[CultureInfo cultureInfo]
    {
        get => _toEntity[cultureInfo];
    }

    public CultureInfo this[Entity.User.UserPreferenceApplicationCulture userPreferenceApplicationCulture]
    {
        get => _toCultureInfo[userPreferenceApplicationCulture];
    }
}
