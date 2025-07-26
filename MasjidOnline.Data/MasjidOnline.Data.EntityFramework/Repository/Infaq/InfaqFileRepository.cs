using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

// todo low change *DataContext to DbContext
public class InfaqFileRepository(InfaqDataContext _infaqDataContext) : IInfaqFileRepository
{
    private readonly DbSet<InfaqFile> _dbSet = _infaqDataContext.Set<InfaqFile>();

    public async Task AddAsync(InfaqFile infaqFile)
    {
        await _dbSet.AddAsync(infaqFile);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
