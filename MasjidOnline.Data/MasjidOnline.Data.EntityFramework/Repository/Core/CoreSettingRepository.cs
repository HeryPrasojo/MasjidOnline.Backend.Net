using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Core;
using MasjidOnline.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Core;

public class CoreSettingRepository(CoreDataContext _dataContext) : ICoreSettingRepository
{
    private readonly DbSet<CoreSetting> _dbSet = _dataContext.Set<CoreSetting>();

    public async Task AddAsync(CoreSetting coreSetting)
    {
        await _dbSet.AddAsync(coreSetting);
    }
}
