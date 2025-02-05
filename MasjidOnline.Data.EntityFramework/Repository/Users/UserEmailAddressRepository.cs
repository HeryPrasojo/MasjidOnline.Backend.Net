using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.User;
using MasjidOnline.Data.Interface.Repository.Users;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Users;

public class UserEmailAddressRepository(UsersDataContext _userDataContext) : IUserEmailAddressRepository
{
    private readonly DbSet<UserEmailAddress> _dbSet = _userDataContext.Set<UserEmailAddress>();

    public async Task AddAsync(UserEmailAddress userEmailAddress)
    {
        await _dbSet.AddAsync(userEmailAddress);
    }

    public async Task<UserEmailAddressForLogin?> GetForLoginAsync(string emailAddress)
    {
        return await _dbSet.Where(e => e.EmailAddress == emailAddress)
            .Select(e => new UserEmailAddressForLogin
            {
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }
}
