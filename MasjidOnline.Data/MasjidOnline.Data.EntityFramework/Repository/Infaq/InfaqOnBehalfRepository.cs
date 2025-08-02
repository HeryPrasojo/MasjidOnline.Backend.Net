using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class InfaqOnBehalfRepository(DbContext _dbContext) : IInfaqOnBehalfRepository
{
    private readonly DbSet<InfaqOnBehalf> _dbSet = _dbContext.Set<InfaqOnBehalf>();

    public async Task AddAsync(InfaqOnBehalf infaqOnBehalf)
    {
        await _dbSet.AddAsync(infaqOnBehalf);
    }
}
