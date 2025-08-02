using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Authorization;
using MasjidOnline.Entity.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Authorization;

public class AuthorizationSettingRepository(DbContext _dbContext) : IAuthorizationSettingRepository
{
    private readonly DbSet<AuthorizationSetting> _dbSet = _dbContext.Set<AuthorizationSetting>();

    public async Task AddAndSaveAsync(AuthorizationSetting authorizationSetting)
    {
        await _dbSet.AddAsync(authorizationSetting);

        await _dbContext.SaveChangesAsync();
    }
}
