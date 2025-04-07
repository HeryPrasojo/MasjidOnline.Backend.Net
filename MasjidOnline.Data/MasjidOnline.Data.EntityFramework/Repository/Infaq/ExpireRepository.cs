using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Expire;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class ExpireRepository(InfaqDataContext _infaqDataContext) : IExpireRepository
{
    private readonly DbSet<Expire> _dbSet = _infaqDataContext.Set<Expire>();

    public async Task AddAsync(Expire expire)
    {
        await _dbSet.AddAsync(expire);
    }

    public async Task<bool> AnyAsync(int infaqId, ExpireStatus status)
    {
        return await _dbSet.AnyAsync(e => (e.InfaqId == infaqId) && (e.Status == status));
    }

    public async Task<ForSetStatus?> GetForSetStatusAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new ForSetStatus
            {
                InfaqId = e.InfaqId,
                Status = e.Status,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ManyResult<ManyRecord>> GetManyAsync(
        ExpireStatus? status = default,
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
            if (orderByDirection == OrderByDirection.Descending) queryable = queryable.OrderByDescending(e => e.DateTime);
            else queryable = queryable.OrderBy(e => e.DateTime);
        }

        var count = await countTask;

        return new()
        {
            Records = await queryable.Skip(skip)
                .Take(take)
                .Select(e => new ManyRecord
                {
                    Id = e.Id,
                    DateTime = e.DateTime,
                    InfaqId = e.InfaqId,
                    Status = e.Status,
                    UpdateDateTime = e.UpdateDateTime,
                    UpdateUserId = e.UpdateUserId,
                    UserId = e.UserId,
                })
                .ToArrayAsync(),
            Total = count,
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
                DateTime = e.DateTime,
                Description = e.Description,
                InfaqId = e.InfaqId,
                Status = e.Status,
                UpdateDateTime = e.UpdateDateTime,
                UpdateUserId = e.UpdateUserId,
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }

    public void SetStatus(int id, ExpireStatus status, string? description, DateTime updateDateTime, int updateUserId)
    {
        var expire = new Expire
        {
            Description = description,
            Id = id,
            Status = status,
            UpdateDateTime = updateDateTime,
            UpdateUserId = updateUserId,
        };

        var entityEntry = _dbSet.Attach(expire);

        entityEntry.Property(e => e.Description).IsModified = true;
        entityEntry.Property(e => e.Status).IsModified = true;
        entityEntry.Property(e => e.UpdateDateTime).IsModified = true;
        entityEntry.Property(e => e.UpdateUserId).IsModified = true;
    }
}
