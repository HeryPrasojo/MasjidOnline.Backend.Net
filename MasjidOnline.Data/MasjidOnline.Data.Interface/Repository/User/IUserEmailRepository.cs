using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.User.UserEmail;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IUserEmailRepository
{
    Task AddAsync(UserEmail userEmail);
    Task<bool> AnyAsync(string emailAddress);
    Task<IEnumerable<ForOneInternalUser>?> GetForOneInternalUserAsync(IEnumerable<int> ids);
    Task<int> GetMaxIdAsync();
    Task<int> GetUserIdAsync(string emailAddress);
}
