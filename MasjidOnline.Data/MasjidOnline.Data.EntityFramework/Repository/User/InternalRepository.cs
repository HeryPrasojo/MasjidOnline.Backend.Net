using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class InternalRepository(UserDataContext _userDataContext) : IInternalRepository
{
    private readonly DbSet<Internal> _dbSet = _userDataContext.Set<Internal>();

    public async Task AddAsync(Internal @internal)
    {
        await _dbSet.AddAsync(@internal);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
