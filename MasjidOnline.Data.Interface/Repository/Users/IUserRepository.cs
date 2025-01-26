using System.Threading.Tasks;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Interface.Repository.Users;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<int> GetMaxIdAsync();
}
