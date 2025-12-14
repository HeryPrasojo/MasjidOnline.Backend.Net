using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.User.User;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IUserRepository
{
    Task AddAsync(Entity.User.User user);
    Task<bool> GetAnyAsync(int id);
    Task<ForLogin?> GetForLoginAsync(int id);
    Task<int> GetMaxIdAsync();
    Task<UserStatus> GetStatusAsync(int id);
    Task<UserType> GetTypeAsync(int id);
    Entity.User.User SetPassword(int id, byte[] password);
}
