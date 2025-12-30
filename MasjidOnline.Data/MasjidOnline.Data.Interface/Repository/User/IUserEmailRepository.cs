using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IUserEmailRepository
{
    Task AddAsync(UserEmail userEmail);
    Task<bool> AnyAsync(string emailAddress);
    Task<int> GetMaxIdAsync();
    Task<int> GetUserIdAsync(string emailAddress);
}
