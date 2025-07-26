using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Authorization;
using MasjidOnline.Entity.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Authorization;

// todo low change *DataContext to DbContext
public class AuthorizationSettingRepository(AuthorizationDataContext _authorizationDataContext) : IAuthorizationSettingRepository
{
    private readonly DbSet<AuthorizationSetting> _dbSet = _authorizationDataContext.Set<AuthorizationSetting>();

    public async Task AddAsync(AuthorizationSetting authorizationSetting)
    {
        await _dbSet.AddAsync(authorizationSetting);
    }
}
