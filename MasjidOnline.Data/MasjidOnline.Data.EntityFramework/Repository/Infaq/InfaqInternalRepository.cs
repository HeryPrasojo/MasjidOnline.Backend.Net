using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class InfaqInternalRepository(InfaqDataContext _infaqDataContext) : IInfaqInternalRepository
{
    private readonly DbSet<InfaqInternal> _dbSet = _infaqDataContext.Set<InfaqInternal>();

    public async Task AddAsync(InfaqInternal infaqInternal)
    {
        await _dbSet.AddAsync(infaqInternal);
    }
}
