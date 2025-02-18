using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaqs;
using MasjidOnline.Entity.Infaqs;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaqs;

public class InfaqFileRepository(InfaqsDataContext _infaqsDataContext) : IInfaqFileRepository
{
    private readonly DbSet<InfaqFile> _dbSet = _infaqsDataContext.Set<InfaqFile>();

    public async Task AddAsync(InfaqFile infaqFile)
    {
        await _dbSet.AddAsync(infaqFile);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
