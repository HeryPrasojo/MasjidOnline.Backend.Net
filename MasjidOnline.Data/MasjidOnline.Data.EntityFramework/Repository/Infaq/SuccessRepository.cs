using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Success;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class SuccessRepository(InfaqDataContext _infaqDataContext) : ISuccessRepository
{
    private readonly DbSet<Success> _dbSet = _infaqDataContext.Set<Success>();

    public async Task AddAsync(Success success)
    {
        await _dbSet.AddAsync(success);
    }

    public async Task<bool> AnyAsync(int infaqId, SuccessStatus status)
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
        SuccessStatus? status = default,
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
                    DateTime = e.DateTime,
                    Id = e.Id,
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

    public async Task<ManyResult<ManyNewRecord>> GetManyNewAsync(
        ManyOrderBy getManyOrderBy = default,
        OrderByDirection orderByDirection = default,
        int skip = 0,
        int take = 1)
    {
        var queryable = _dbSet.Where(e => e.Status == SuccessStatus.New);


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
                .Select(e => new ManyNewRecord
                {
                    DateTime = e.DateTime,
                    Id = e.Id,
                    InfaqId = e.InfaqId,
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
                Status = e.Status,
                UpdateDateTime = e.UpdateDateTime,
                UpdateUserId = e.UpdateUserId,
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<OneNew?> GetOneNewAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new OneNew
            {
                DateTime = e.DateTime,
                InfaqId = e.InfaqId,
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }

    //public async Task<SuccessStatus> GetStatusAsync(int id)
    //{
    //    return await _dbSet.Where(e => e.Id == id)
    //        .Select(e => e.Status)
    //        .FirstOrDefaultAsync();
    //}

    public void SetStatus(int id, SuccessStatus status, string? description, DateTime updateDateTime, int updateUserId)
    {
        var success = new Success
        {
            Description = description,
            Id = id,
            Status = status,
            UpdateDateTime = updateDateTime,
            UpdateUserId = updateUserId,
        };

        var entityEntry = _dbSet.Attach(success);

        entityEntry.Property(e => e.Description).IsModified = true;
        entityEntry.Property(e => e.Status).IsModified = true;
        entityEntry.Property(e => e.UpdateDateTime).IsModified = true;
        entityEntry.Property(e => e.UpdateUserId).IsModified = true;
    }
}
