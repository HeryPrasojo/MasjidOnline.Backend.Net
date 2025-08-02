using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class InfaqSettingRepository(DbContext _dbContext) : IInfaqSettingRepository
{
    private readonly DbSet<InfaqSetting> _dbSet = _dbContext.Set<InfaqSetting>();

    public async Task AddAndSaveAsync(InfaqSetting infaqSetting)
    {
        await _dbSet.AddAsync(infaqSetting);

        await _dbContext.SaveChangesAsync();
    }
}
