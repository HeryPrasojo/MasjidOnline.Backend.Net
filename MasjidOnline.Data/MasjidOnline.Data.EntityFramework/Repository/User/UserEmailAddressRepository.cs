using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.User;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class UserEmailAddressRepository(UserDataContext _userDataContext) : IUserEmailAddressRepository
{
    private readonly DbSet<UserEmailAddress> _dbSet = _userDataContext.Set<UserEmailAddress>();

    public async Task AddAsync(UserEmailAddress userEmailAddress)
    {
        await _dbSet.AddAsync(userEmailAddress);
    }

    public async Task<bool> AnyByEmailAddressAsync(string emailAddress)
    {
        return await _dbSet.AnyAsync(e => e.EmailAddress == emailAddress);
    }

    public async Task<UserEmailAddressForUserLogin?> GetForUserLoginAsync(string emailAddress)
    {
        return await _dbSet.Where(e => e.EmailAddress == emailAddress)
            .Select(e => new UserEmailAddressForUserLogin
            {
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }
}
