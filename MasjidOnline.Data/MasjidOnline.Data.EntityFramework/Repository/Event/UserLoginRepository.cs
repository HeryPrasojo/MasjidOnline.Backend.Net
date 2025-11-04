using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Event;
using MasjidOnline.Entity.Event;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Event;

public class UserLoginRepository(DbContext _dbContext) : IUserLoginRepository
{
    private readonly DbSet<UserLogin> _dbSet = _dbContext.Set<UserLogin>();

    public async Task AddAsync(UserLogin userLogin)
    {
        await _dbSet.AddAsync(userLogin);
    }


    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
