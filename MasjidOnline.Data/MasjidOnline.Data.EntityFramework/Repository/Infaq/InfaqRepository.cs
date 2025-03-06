using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.Infaq.Infaq;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class InfaqRepository(InfaqDataContext _infaqDataContext) : IInfaqRepository
{
    private readonly DbSet<Entity.Infaq.Infaq> _dbSet = _infaqDataContext.Set<Entity.Infaq.Infaq>();

    public async Task AddAsync(Entity.Infaq.Infaq infaq)
    {
        await _dbSet.AddAsync(infaq);
    }

    public async Task<ExpiredAdd?> GetForExpiredAddAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new ExpiredAdd
            {
                DateTime = e.DateTime,
                PaymentStatus = e.PaymentStatus,
                PaymentType = e.PaymentType,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ManyResult<ManyRecord>> GetManyAsync(
        IEnumerable<PaymentType>? paymentTypes = default,
        IEnumerable<PaymentStatus>? paymentStatuses = default,
        ManyOrderBy getManyOrderBy = default,
        OrderByDirection orderByDirection = default,
        int skip = 0,
        int take = 1)
    {
        var queryable = _dbSet.AsQueryable();

        if (paymentStatuses != default)
            queryable = queryable.Where(e => paymentStatuses.Any(s => s == e.PaymentStatus));

        if (paymentTypes != default)
            queryable = queryable.Where(e => paymentTypes.Any(s => s == e.PaymentType));


        var countTask = queryable.LongCountAsync();


        if (getManyOrderBy == ManyOrderBy.Id)
        {
            if (orderByDirection == OrderByDirection.Descending) queryable = queryable.OrderByDescending(e => e.Id);
            else queryable = queryable.OrderBy(e => e.Id);
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
                    Id = e.Id,
                    MunfiqName = e.MunfiqName,
                    PaymentStatus = e.PaymentStatus,
                    PaymentType = e.PaymentType,
                })
                .ToArrayAsync(),
            Total = count,
        };
    }

    public async Task<ManyResult<ManyDueRecord>> GetManyDueAsync(
        DateTime dueDateTime,
        IEnumerable<PaymentType>? paymentTypes = default,
        ManyOrderBy getManyOrderBy = default,
        OrderByDirection orderByDirection = default,
        int skip = 0,
        int take = 1)
    {
        var queryable = _dbSet.Where(e => e.PaymentStatus == PaymentStatus.Pending && e.DateTime < dueDateTime);

        if (paymentTypes != default)
            queryable = queryable.Where(e => paymentTypes.Any(s => s == e.PaymentType));


        var countTask = queryable.LongCountAsync();


        if (getManyOrderBy == ManyOrderBy.Id)
        {
            if (orderByDirection == OrderByDirection.Descending) queryable = queryable.OrderByDescending(e => e.Id);
            else queryable = queryable.OrderBy(e => e.Id);
        }


        var count = await countTask;

        return new()
        {
            Records = await queryable.Skip(skip)
                .Take(take)
                .Select(e => new ManyDueRecord
                {
                    Amount = e.Amount,
                    DateTime = e.DateTime,
                    Id = e.Id,
                    MunfiqName = e.MunfiqName,
                    PaymentType = e.PaymentType,
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
                Amount = e.Amount,
                DateTime = e.DateTime,
                MunfiqName = e.MunfiqName,
                PaymentStatus = e.PaymentStatus,
                PaymentType = e.PaymentType,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<OneDue?> GetOneDueAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new OneDue
            {
                Amount = e.Amount,
                DateTime = e.DateTime,
                MunfiqName = e.MunfiqName,
                PaymentStatus = e.PaymentStatus,
                PaymentType = e.PaymentType,
            })
            .FirstOrDefaultAsync();
    }


    public void UpdatePaymentStatus(int id, PaymentStatus paymentStatus)
    {
        var infaq = new Entity.Infaq.Infaq
        {
            Id = id,
            PaymentStatus = paymentStatus,
        };

        _dbSet.Attach(infaq)
            .Property(e => e.PaymentStatus)
            .IsModified = true;
    }
}
