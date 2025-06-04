using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class UserPreferenceRepository(UserDataContext _userDataContext) : IUserPreferenceRepository
{
    private readonly DbSet<UserPreference> _dbSet = _userDataContext.Set<UserPreference>();

    public async Task<bool> AnyAsync(int userId)
    {
        return await _dbSet.AnyAsync(e => e.UserId == userId);
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
