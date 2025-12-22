using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Accountancy;
using MasjidOnline.Data.Interface.ViewModel.Accountancy.Expenditure;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Accountancy;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Accountancy;

public class ExpenditureRepository(DbContext _dbContext) : IExpenditureRepository
{
    private readonly DbSet<Expenditure> _dbSet = _dbContext.Set<Expenditure>();

    public async Task AddAndSaveAsync(Expenditure expenditure)
    {
        await _dbSet.AddAsync(expenditure);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<ForApprove?> GetForApproveAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new ForApprove
            {
                Amount = e.Amount,
                Description = e.Description,
                Status = e.Status,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ManyResult<ManyRecord>> GetManyAsync(
        ExpenditureStatus? status = default,
        ManyOrderBy getManyOrderBy = default,
        OrderByDirection orderByDirection = default,
        int skip = 0,
        int take = 1)
    {
        var queryable = _dbSet.AsQueryable();

        if (status != default)
            queryable = queryable.Where(e => e.Status == status);


        var countTask = queryable.LongCountAsync();


        if (getManyOrderBy == ManyOrderBy.DateTime)
        {
            if (orderByDirection == OrderByDirection.Ascending) queryable = queryable.OrderBy(e => e.DateTime);
            else if (orderByDirection == OrderByDirection.Descending) queryable = queryable.OrderByDescending(e => e.DateTime);
        }


        var count = await countTask;

        return new()
        {
            Records = await queryable.Skip(skip)
                .Take(take)
                .Select(e => new ManyRecord
                {
                    Amount = e.Amount,
                    DateTime = e.DateTime,
                    Description = e.Description,
                    Id = e.Id,
                    Status = e.Status,
                    StatusDescription = e.StatusDescription,
                    UpdateDateTime = e.UpdateDateTime,
                    UpdateUserId = e.UpdateUserId,
                    UserId = e.UserId,
                })
                .ToArrayAsync(),
            RecordCount = count,
        };
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<One?> GetOneAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new One
            {
                Amount = e.Amount,
                DateTime = e.DateTime,
                Description = e.Description,
                Status = e.Status,
                UpdateDateTime = e.UpdateDateTime,
                UpdateUserId = e.UpdateUserId,
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ExpenditureStatus> GetStatusAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => e.Status)
            .FirstOrDefaultAsync();
    }

    public async Task SetStatusAndSaveAsync(int id, ExpenditureStatus status, string? statusDescription, DateTime updateDateTime, int updateUserId)
    {
        var expenditure = new Expenditure
        {
            Id = id,
            Status = status,
            StatusDescription = statusDescription,
            UpdateDateTime = updateDateTime,
            UpdateUserId = updateUserId,
        };

        var entityEntry = _dbSet.Attach(expenditure);

        entityEntry.Property(e => e.Status).IsModified = true;
        entityEntry.Property(e => e.StatusDescription).IsModified = true;
        entityEntry.Property(e => e.UpdateDateTime).IsModified = true;
        entityEntry.Property(e => e.UpdateUserId).IsModified = true;


        await _dbContext.SaveChangesAsync();
    }
}
