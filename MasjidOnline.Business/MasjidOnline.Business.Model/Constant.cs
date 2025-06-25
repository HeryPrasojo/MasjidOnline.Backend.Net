using System.Collections.Generic;

namespace MasjidOnline.Business.Model;

public static class Constant
{
    public const string DefaultUserPreferenceApplicationCulture = "en";
    public const string SystemUserEmailAddress = "system@masjidonline.org";

    public static class Path
    {
        public const string InfaqFileDirectory = "..\\..\\file\\infaq\\";
    }

    public static class StringMapper
    {
        public static class UserPreferenceApplicationCulture
        {
            public static readonly Dictionary<string, Entity.User.UserPreferenceApplicationCulture> FromCultureName = new()
        {
            { DefaultUserPreferenceApplicationCulture, Entity.User.UserPreferenceApplicationCulture.English }
        };
            public static readonly Dictionary<Entity.User.UserPreferenceApplicationCulture, string> ToCultureName = new()
        {
            { Entity.User.UserPreferenceApplicationCulture.English, DefaultUserPreferenceApplicationCulture }
        };
        }
    }

    public static class UserId
    {
        public const int Anonymous = 1;
        public const int System = 2;
        public const int Root = 3;
    }
}
