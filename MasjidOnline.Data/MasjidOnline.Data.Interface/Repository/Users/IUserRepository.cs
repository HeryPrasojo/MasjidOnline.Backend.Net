using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.User;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Interface.Repository.Users;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<bool> GetAnyByIdAsync(int id);
    Task<UserForLogin?> GetForLoginAsync(int id);
    Task<int> GetMaxIdAsync();
    Task<UserType> GetTypeByIdAsync(int userId);
    void UpdateSetPassword(int id, byte[] password);
}
