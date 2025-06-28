using System.Collections.Generic;
using System.Globalization;

namespace MasjidOnline.Business.Model;

public static class Constant
{
    public const string SystemUserEmailAddress = "system@masjidonline.org";

    public static class Path
    {
        public const string InfaqFileDirectory = "..\\..\\file\\infaq\\";
    }

    public static class UserId
    {
        public const int Anonymous = 1;
        public const int System = 2;
        public const int Root = 3;
    }

    public static class UserPreferenceApplicationCulture
    {
        public static readonly Dictionary<CultureInfo, Entity.User.UserPreferenceApplicationCulture> FromCultureInfo = new()
        {
            { Service.Localization.Interface.Model.Constant.CultureInfoEnglish, Entity.User.UserPreferenceApplicationCulture.English },
        };

        public static readonly Dictionary<Entity.User.UserPreferenceApplicationCulture, CultureInfo> ToCultureInfo = new()
        {
            { Entity.User.UserPreferenceApplicationCulture.English, Service.Localization.Interface.Model.Constant.CultureInfoEnglish },
        };
    }
}
