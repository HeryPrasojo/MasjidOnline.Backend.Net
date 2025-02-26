using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaqs;
using MasjidOnline.Entity.Infaqs;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaqs;

public class ExpiredRepository(InfaqsDataContext _infaqsDataContext) : IExpiredRepository
{
    private readonly DbSet<Expired> _dbSet = _infaqsDataContext.Set<Expired>();

    public async Task AddAsync(Expired expired)
    {
        await _dbSet.AddAsync(expired);
    }
}
