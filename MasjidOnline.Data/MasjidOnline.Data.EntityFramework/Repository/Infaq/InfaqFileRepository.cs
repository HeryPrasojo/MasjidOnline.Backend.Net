using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class InfaqFileRepository(DbContext _dbContext) : IInfaqFileRepository
{
    private readonly DbSet<InfaqFile> _dbSet = _dbContext.Set<InfaqFile>();

    public async Task AddAsync(InfaqFile infaqFile)
    {
        await _dbSet.AddAsync(infaqFile);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
