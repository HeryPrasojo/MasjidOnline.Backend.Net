using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IUserEmailAddressRepository
{
    Task AddAsync(UserEmailAddress userEmailAddress);
    Task<bool> AnyAsync(string emailAddress);
    Task<int?> GetUserIdAsync(string emailAddress);
}
