using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.User.UserData;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IUserDataRepository
{
    Task AddAsync(UserData userData);
    Task<bool> AnyAsync(int userId);
    Task<ApplicationCulture?> GetApplicationCultureAsync(int userId);
    Task<IEnumerable<ForOneInternalUser>?> GetForOneInternalUserAsync(IEnumerable<int> userIds);
    void SetApplicationCulture(int userId, ApplicationCulture applicationCulture);
}
