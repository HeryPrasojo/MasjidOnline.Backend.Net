using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IUserPreferenceRepository
{
    Task<bool> AnyAsync(int userId);
}
