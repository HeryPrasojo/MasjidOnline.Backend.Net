using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Repository.Accountancy;
using MasjidOnline.Entity.Accountancy;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Accountancy;

public class ExpenditureRepository(AccountancyDataContext _accountancyDataContext, IAccountancyIdGenerator _accountancyIdGenerator) : IExpenditureRepository
{
    private readonly DbSet<Expenditure> _dbSet = _accountancyDataContext.Set<Expenditure>();

    public Task AddAddAsync(Expenditure expenditure, DateTime dateTime, int userId) => throw new NotImplementedException();

    public async Task<int> GetMaxExpenditureIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
