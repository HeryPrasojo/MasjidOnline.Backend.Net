using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class InfaqManualRepository(DbContext _dbContext) : IInfaqManualRepository
{
    private readonly DbSet<InfaqManual> _dbSet = _dbContext.Set<InfaqManual>();

    public async Task AddAsync(InfaqManual infaqManual)
    {
        await _dbSet.AddAsync(infaqManual);
    }
}
