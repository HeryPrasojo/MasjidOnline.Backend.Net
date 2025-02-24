using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.User;
using MasjidOnline.Data.Interface.Repository.Users;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Users;

public class UserRepository(UsersDataContext _userDataContext) : IUserRepository
{
    private readonly DbSet<User> _dbSet = _userDataContext.Set<User>();

    public async Task AddAsync(User user)
    {
        await _dbSet.AddAsync(user);
    }


    public async Task<bool> GetAnyByIdAsync(int id)
    {
        return await _dbSet.AnyAsync(e => e.Id == id);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<UserType> GetTypeByIdAsync(int userId)
    {
        return await _dbSet.Where(e => e.Id == userId)
            .Select(e => e.Type)
            .FirstOrDefaultAsync();
    }


    public async Task<UserForLogin?> GetForLoginAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new UserForLogin
            {
                Password = e.Password,
            })
            .FirstOrDefaultAsync();
    }


    public void UpdatePassword(int id, byte[] password)
    {
        var user = new User
        {
            Id = id,
            Password = password,
        };

        _dbSet.Attach(user)
            .Property(e => e.Password)
            .IsModified = true;
    }
}
