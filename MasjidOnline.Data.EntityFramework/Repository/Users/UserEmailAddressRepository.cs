using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
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

    public async Task<UserEmailAddress?> GetFirstByEmailAddressAsync(string emailAddress)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.EmailAddress == emailAddress);
    }
}
