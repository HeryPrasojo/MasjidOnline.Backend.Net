using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class InfaqManualRepository(InfaqDataContext _infaqDataContext) : IInfaqManualRepository
{
    private readonly DbSet<InfaqManual> _dbSet = _infaqDataContext.Set<InfaqManual>();

    public async Task AddAsync(InfaqManual infaqManual)
    {
        await _dbSet.AddAsync(infaqManual);
    }
}
