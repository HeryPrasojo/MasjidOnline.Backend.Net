using System.Collections.Generic;
using System.Globalization;

namespace MasjidOnline.Business.Mapper.Session;

public class UserPreferenceApplicationCultureMapper
{
    private static readonly Dictionary<Entity.User.ApplicationCulture, CultureInfo> _toCultureInfo = new()
    {
        { Entity.User.ApplicationCulture.English,    Service.Localization.Interface.Constant.English.CultureInfo },
        { Entity.User.ApplicationCulture.Indonesian, Service.Localization.Interface.Constant.Indonesian.CultureInfo },
    };

    private static readonly Dictionary<CultureInfo, Entity.User.ApplicationCulture> _toEntity = new()
    {
        { Service.Localization.Interface.Constant.English.CultureInfo, Entity.User.ApplicationCulture.English },
    };


    public CultureInfo this[Entity.User.ApplicationCulture applicationCulture]
    {
        get => _toCultureInfo[applicationCulture];
    }

    public Entity.User.ApplicationCulture this[CultureInfo cultureInfo]
    {
        get => _toEntity[cultureInfo];
    }
}
