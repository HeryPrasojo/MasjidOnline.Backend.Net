using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.DatabaseTemplate;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.DatabaseTemplate;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.DatabaseTemplate;

public class TableTemplateRepository(DatabaseTemplateDataContext _databaseTemplateDataContext) : ITableTemplateRepository
{
    private readonly DbSet<TableTemplate> _dbSet = _databaseTemplateDataContext.Set<TableTemplate>();

    public async Task AddAsync(TableTemplate table)
    {
        await _dbSet.AddAsync(table);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
