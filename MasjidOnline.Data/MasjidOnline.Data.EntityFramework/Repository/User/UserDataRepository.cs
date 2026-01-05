using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Data.Interface.ViewModel.User.UserData;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class UserDataRepository(DbContext _dbContext) : IUserDataRepository
{
    private readonly DbSet<UserData> _dbSet = _dbContext.Set<UserData>();

    public async Task AddAsync(UserData userData)
    {
        await _dbSet.AddAsync(userData);
    }

    public async Task<bool> AnyAsync(int userId)
    {
        return await _dbSet.AnyAsync(e => e.UserId == userId);
    }

    public async Task<ApplicationCulture?> GetApplicationCultureAsync(int userId)
    {
        return await _dbSet.Where(e => e.UserId == userId)
            .Select(e => e.ApplicationCulture)
            .FirstOrDefaultAsync();
    }


    public async Task<IEnumerable<ForOneInternalUser>?> GetForOneInternalUserAsync(IEnumerable<int> userIds)
    {
        return await _dbSet.Where(e => userIds.Any(i => i == e.UserId))
            .Select(e => new ForOneInternalUser
            {
                MainContactId = e.MainContactId,
                MainContactType = e.MainContactType,
                UserId = e.UserId,
            })
            .ToArrayAsync();
    }


    public void SetApplicationCulture(int userId, ApplicationCulture applicationCulture)
    {
        var user = new UserData
        {
            UserId = userId,
            ApplicationCulture = applicationCulture,
        };

        var entityEntry = _dbSet.Attach(user);

        entityEntry.Property(e => e.ApplicationCulture).IsModified = true;
    }
}
