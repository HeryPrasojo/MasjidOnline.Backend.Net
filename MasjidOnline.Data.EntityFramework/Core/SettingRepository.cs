using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Core;

public class SettingRepository(DataContext _dataContext) : ISettingRepository
{
    private readonly DbSet<Setting> _dbSet = _dataContext.Set<Setting>();

    public async Task AddAsync(Setting setting)
    {
        await _dbSet.AddAsync(setting);
    }
}
