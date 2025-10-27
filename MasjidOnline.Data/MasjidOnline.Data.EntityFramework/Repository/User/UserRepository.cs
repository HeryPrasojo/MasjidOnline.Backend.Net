using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Data.Interface.ViewModel.User.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class UserRepository(DbContext _dbContext) : IUserRepository
{
    private readonly DbSet<Entity.User.User> _dbSet = _dbContext.Set<Entity.User.User>();

    public async Task AddAsync(Entity.User.User user)
    {
        await _dbSet.AddAsync(user);
    }


    public async Task<bool> GetAnyAsync(int id)
    {
        return await _dbSet.AnyAsync(e => e.Id == id);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<UserStatus> GetStatusAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => e.Status)
            .FirstOrDefaultAsync();
    }

    public async Task<UserType> GetTypeAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => e.Type)
            .FirstOrDefaultAsync();
    }


    public async Task<ForLogin?> GetForLoginAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new ForLogin
            {
                Password = e.Password,
            })
            .FirstOrDefaultAsync();
    }


    public Entity.User.User SetFirstPassword(int id, byte[] password)
    {
        var user = new Entity.User.User
        {
            Id = id,
            Password = password,
            Status = UserStatus.Active,
        };

        var entityEntry = _dbSet.Attach(user);

        entityEntry.Property(e => e.Password).IsModified = true;
        entityEntry.Property(e => e.Status).IsModified = true;

        return user;
    }

    public Entity.User.User SetPassword(int id, byte[] password)
    {
        var user = new Entity.User.User
        {
            Id = id,
            Password = password,
        };

        var entityEntry = _dbSet.Attach(user);

        entityEntry.Property(e => e.Password).IsModified = true;

        return user;
    }
}
