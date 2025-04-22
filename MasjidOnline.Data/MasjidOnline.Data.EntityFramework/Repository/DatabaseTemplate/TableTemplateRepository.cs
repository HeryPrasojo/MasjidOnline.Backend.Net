using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Database;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Database;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.DatabaseTemplate;

public class TableTemplateRepository(DatabaseTemplateDataContext _databaseTemplateDataContext) : ITableRepository
{
    private readonly DbSet<Table> _dbSet = _databaseTemplateDataContext.Set<Table>();

    public async Task AddAsync(Table table)
    {
        await _dbSet.AddAsync(table);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
