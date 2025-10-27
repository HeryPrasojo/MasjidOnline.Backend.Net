using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class UserPreferenceRepository(DbContext _dbContext) : IUserPreferenceRepository
{
    private readonly DbSet<UserPreference> _dbSet = _dbContext.Set<UserPreference>();

    public async Task AddAsync(UserPreference userPreference)
    {
        await _dbSet.AddAsync(userPreference);
    }

    public async Task<bool> AnyAsync(int userId)
    {
        return await _dbSet.AnyAsync(e => e.UserId == userId);
    }

    public async Task<UserPreferenceApplicationCulture> GetApplicationCultureAsync(int userId)
    {
        return await _dbSet.Where(e => e.UserId == userId)
            .Select(e => e.ApplicationCulture)
            .FirstOrDefaultAsync();
    }


    public void SetApplicationCulture(int userId, UserPreferenceApplicationCulture applicationCulture)
    {
        var user = new UserPreference
        {
            UserId = userId,
            ApplicationCulture = applicationCulture,
        };

        var entityEntry = _dbSet.Attach(user);

        entityEntry.Property(e => e.ApplicationCulture).IsModified = true;
    }
}
