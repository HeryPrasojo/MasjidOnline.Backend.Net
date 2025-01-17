using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Users;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Users;

public class UserRepository(UserDataContext _userDataContext) : IUserRepository
{
    private readonly DbSet<User> _dbSet = _userDataContext.Set<User>();

    public async Task AddAsync(User user)
    {
        await _dbSet.AddAsync(user);
    }

    public async Task AddAndSaveAsync(User user)
    {
        await AddAsync(user);

        await SaveAsync();
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }


    private async Task<int> SaveAsync()
    {
        return await _userDataContext.SaveChangesAsync();
    }
}
