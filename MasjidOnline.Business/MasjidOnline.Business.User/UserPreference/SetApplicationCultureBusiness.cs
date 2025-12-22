using System.Threading.Tasks;
using MasjidOnline.Business.User.Interface.Model.UserPreference;
using MasjidOnline.Business.User.Interface.UserPreference;

namespace MasjidOnline.Business.User.UserPreference;

public class SetApplicationCultureBusiness : IUserPreference
{
    public async Task<UserPreferenceApplicationCulture> SetAsync(SetApplicationCultureRequest setApplicationCultureRequest)
    {
        var e = Mapper.Mapper.User.UserPreferenceApplicationCulture[setApplicationCultureRequest.ApplicationCulture!.Value];



        return Mapper.Mapper.User.UserPreferenceApplicationCulture[e];
    }
}
