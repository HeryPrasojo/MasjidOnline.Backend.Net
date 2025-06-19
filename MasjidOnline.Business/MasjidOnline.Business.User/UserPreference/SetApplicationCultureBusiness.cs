using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.User.Interface.UserPreference;
using MasjidOnline.Business.User.UserPreference.Mapper;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.UserPreference;

public class SetApplicationCultureBusiness : ISetApplicationCultureBusiness
{
    private const string defaultSupportedCulture = "en";

    private static readonly string[] supportedCultures = [defaultSupportedCulture];

    public async Task<string> SetAsync(IData _data, Session.Interface.Model.Session session, string cultureName)
    {
        if (!string.IsNullOrWhiteSpace(cultureName))
        {
            var anySupportedCulture = supportedCultures.Any(c => c == cultureName);

            if (anySupportedCulture)
            {
                if (!session.IsUserAnonymous)
                {
                    var anyUserPreference = await _data.User.UserPreference.AnyAsync(session.UserId);

                    if (anyUserPreference)
                    {
                        var userPreferenceApplicationCulture = UserPreferenceApplicationCultureMapper.FromString(cultureName);

                        _data.User.UserPreference.SetApplicationCulture(session.UserId, userPreferenceApplicationCulture);

                        await _data.User.SaveAsync();
                    }
                }

                _data.Session.Session.SetApplicationCulture(session.Id,)

                session.ApplicationCulture;

                // todo save session

                return cultureName;
            }
        }

        return defaultSupportedCulture;
    }
}
