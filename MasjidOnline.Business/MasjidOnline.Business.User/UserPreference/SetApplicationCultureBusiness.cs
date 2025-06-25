using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.User.Interface.UserPreference;
using MasjidOnline.Business.User.UserPreference.Mapper;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.UserPreference;

public class SetApplicationCultureBusiness : ISetApplicationCultureBusiness
{
    private static readonly string[] supportedCultures = [Constant.DefaultUserPreferenceApplicationCulture];

    public async Task<string> SetAsync(IData _data, Session.Interface.Model.Session session, string cultureName)
    {
        if (!string.IsNullOrWhiteSpace(cultureName))
        {
            var anySupportedCulture = supportedCultures.Any(c => c == cultureName);

            if (anySupportedCulture)
            {
                await _data.Transaction.BeginAsync(_data.Session, _data.User);

                var userPreferenceApplicationCulture = UserPreferenceApplicationCultureMapper.FromString(cultureName);

                if (!session.IsUserAnonymous)
                {
                    var anyUserPreference = await _data.User.UserPreference.AnyAsync(session.UserId);

                    if (anyUserPreference)
                    {
                        _data.User.UserPreference.SetApplicationCulture(session.UserId, userPreferenceApplicationCulture);
                    }
                }

                _data.Session.Session.SetApplicationCulture(session.Id, userPreferenceApplicationCulture);

                await _data.Transaction.CommitAsync();

                session.ApplicationCultureName = cultureName;

                return cultureName;
            }
        }

        return Constant.DefaultUserPreferenceApplicationCulture;
    }
}
