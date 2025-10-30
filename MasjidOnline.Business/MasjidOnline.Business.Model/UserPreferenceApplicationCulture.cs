using System.Collections.Generic;
using System.Globalization;

namespace MasjidOnline.Business.Model;

public class UserPreferenceApplicationCulture
{
    private static readonly Dictionary<CultureInfo, Entity.User.UserPreferenceApplicationCulture> _toUserPreferenceApplicationCulture = new()
        {
            { Service.Localization.Interface.Model.Constant.CultureInfoEnglish, Entity.User.UserPreferenceApplicationCulture.English },
        };

    private static readonly Dictionary<Entity.User.UserPreferenceApplicationCulture, CultureInfo> _toCultureInfo = new()
        {
            { Entity.User.UserPreferenceApplicationCulture.English, Service.Localization.Interface.Model.Constant.CultureInfoEnglish },
            { Entity.User.UserPreferenceApplicationCulture.Invalid, Service.Localization.Interface.Model.Constant.CultureInfoEnglish },
        };

    public Entity.User.UserPreferenceApplicationCulture this[CultureInfo cultureInfo]
    {
        get => _toUserPreferenceApplicationCulture[cultureInfo];
    }

    public CultureInfo this[Entity.User.UserPreferenceApplicationCulture userPreferenceApplicationCulture]
    {
        get => _toCultureInfo[userPreferenceApplicationCulture];
    }
}
