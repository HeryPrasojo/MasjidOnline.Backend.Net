using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IUserPreferenceRepository
{
    Task AddAsync(UserPreference userPreference);
    Task<bool> AnyAsync(int userId);
    Task<UserPreferenceApplicationCulture> GetApplicationCultureAsync(int userId);
    void SetApplicationCulture(int userId, UserPreferenceApplicationCulture applicationCulture);
}
