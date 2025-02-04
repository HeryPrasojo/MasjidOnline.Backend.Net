using System.Threading.Tasks;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Interface.Repository.Users;

public interface IUserEmailAddressRepository
{
    Task AddAsync(UserEmailAddress userEmailAddress);
    Task<UserEmailAddress?> GetFirstByEmailAddressAsync(string emailAddress);
}
