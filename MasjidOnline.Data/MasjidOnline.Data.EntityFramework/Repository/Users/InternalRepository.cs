using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Users;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Users;

public class InternalRepository(UsersDataContext _usersDataContext) : IInternalRepository
{
    private readonly DbSet<Internal> _dbSet = _usersDataContext.Set<Internal>();

    public async Task AddAsync(Internal @internal)
    {
        await _dbSet.AddAsync(@internal);
    }
}
