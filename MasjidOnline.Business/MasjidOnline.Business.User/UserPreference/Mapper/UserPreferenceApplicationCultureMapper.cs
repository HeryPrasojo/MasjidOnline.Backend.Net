using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.User.UserPreference.Mapper;

public static class UserPreferenceApplicationCultureMapper
{
    public static UserPreferenceApplicationCulture FromString(string cultureName)
    {
        return cultureName switch
        {
            "en" => UserPreferenceApplicationCulture.English,

            _ => throw new ErrorException(nameof(cultureName)),
        };
    }
}
