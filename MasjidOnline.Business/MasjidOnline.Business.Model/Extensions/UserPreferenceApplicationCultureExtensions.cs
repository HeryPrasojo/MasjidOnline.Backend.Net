using MasjidOnline.Entity.User;

namespace MasjidOnline.Business.Model.Extensions;

public static class UserPreferenceApplicationCultureExtensions
{
    public static string ToCultureName(this UserPreferenceApplicationCulture userPreferenceApplicationCulture)
    {
        return Constant.StringMapper.UserPreferenceApplicationCulture.ToCultureName[userPreferenceApplicationCulture];
    }
}
