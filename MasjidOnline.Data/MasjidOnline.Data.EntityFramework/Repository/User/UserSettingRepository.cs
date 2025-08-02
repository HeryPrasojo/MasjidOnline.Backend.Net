using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class UserSettingRepository(DbContext _dbContext) : IUserSettingRepository
{
    private readonly DbSet<UserSetting> _dbSet = _dbContext.Set<UserSetting>();

    public async Task AddAndSaveAsync(UserSetting userSetting)
    {
        await _dbSet.AddAsync(userSetting);

        await _dbContext.SaveChangesAsync();
    }
}
