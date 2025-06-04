using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IUserPreferenceRepository
{
    Task<bool> AnyAsync(int userId);
    void SetApplicationCulture(int userId, UserPreferenceApplicationCulture applicationCulture);
}
