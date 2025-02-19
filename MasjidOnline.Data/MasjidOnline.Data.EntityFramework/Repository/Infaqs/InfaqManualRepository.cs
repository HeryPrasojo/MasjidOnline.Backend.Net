using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaqs;
using MasjidOnline.Entity.Infaqs;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaqs;

public class InfaqManualRepository(InfaqsDataContext _infaqsDataContext) : IInfaqManualRepository
{
    private readonly DbSet<InfaqManual> _dbSet = _infaqsDataContext.Set<InfaqManual>();

    public async Task AddAsync(InfaqManual infaqManual)
    {
        await _dbSet.AddAsync(infaqManual);
    }
}
