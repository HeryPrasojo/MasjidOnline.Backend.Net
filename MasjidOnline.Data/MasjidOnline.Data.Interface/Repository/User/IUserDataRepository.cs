using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IUserDataRepository
{
    Task AddAsync(UserData userData);
    Task<bool> AnyAsync(int userId);
    Task<ApplicationCulture?> GetApplicationCultureAsync(int userId);
    void SetApplicationCulture(int userId, ApplicationCulture applicationCulture);
}
