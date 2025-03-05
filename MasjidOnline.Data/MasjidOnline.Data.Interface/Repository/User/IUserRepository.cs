using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.User;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IUserRepository
{
    Task AddAsync(Entity.User.User user);
    Task<bool> GetAnyByIdAsync(int id);
    Task<UserForLogin?> GetForLoginAsync(int id);
    Task<int> GetMaxIdAsync();
    Task<UserType> GetTypeByIdAsync(int userId);
    void SetPassword(int id, byte[] password);
}
