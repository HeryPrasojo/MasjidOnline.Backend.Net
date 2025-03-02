using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class InfaqSettingRepository(InfaqDataContext _infaqDataContext) : IInfaqSettingRepository
{
    private readonly DbSet<InfaqSetting> _dbSet = _infaqDataContext.Set<InfaqSetting>();

    public async Task AddAsync(InfaqSetting infaqSetting)
    {
        await _dbSet.AddAsync(infaqSetting);
    }
}
