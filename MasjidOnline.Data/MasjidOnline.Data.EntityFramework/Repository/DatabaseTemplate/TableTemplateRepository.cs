using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.DatabaseTemplate;
using MasjidOnline.Entity.DatabaseTemplate;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.DatabaseTemplate;

public class TableTemplateRepository(DbContext _dbContext) : ITableTemplateRepository
{
    private readonly DbSet<TableTemplate> _dbSet = _dbContext.Set<TableTemplate>();

    public async Task AddAsync(TableTemplate table)
    {
        await _dbSet.AddAsync(table);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
