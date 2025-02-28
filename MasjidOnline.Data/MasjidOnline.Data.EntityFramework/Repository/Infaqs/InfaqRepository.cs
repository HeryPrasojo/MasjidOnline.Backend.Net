using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.Infaq;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Data.Interface.Repository.Infaqs;
using MasjidOnline.Entity.Infaqs;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaqs;

public class InfaqRepository(InfaqsDataContext _infaqsDataContext) : IInfaqRepository
{
    private readonly DbSet<Infaq> _dbSet = _infaqsDataContext.Set<Infaq>();

    public async Task AddAsync(Infaq infaq)
    {
        await _dbSet.AddAsync(infaq);
    }

    public async Task AddAndSaveAsync(Infaq infaq)
    {
        await AddAsync(infaq);

        await SaveAsync();
    }

    public async Task<InfaqForExpiredAdd?> GetForExpiredAddAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new InfaqForExpiredAdd
            {
                DateTime = e.DateTime,
                PaymentStatus = e.PaymentStatus,
                PaymentType = e.PaymentType,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<GetManyResult<InfaqForGetManyRecord>> GetManyAsync(
        IEnumerable<PaymentType>? paymentTypes = default,
        IEnumerable<PaymentStatus>? paymentStatuses = default,
        GetManyOrderBy getManyOrderBy = default,
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


        if (getManyOrderBy == GetManyOrderBy.Id)
        {
            if (orderByDirection == OrderByDirection.Descending) queryable = queryable.OrderByDescending(e => e.Id);
            else queryable = queryable.OrderBy(e => e.Id);
        }


        var count = await countTask;

        return new()
        {
            Records = await queryable.Skip(skip)
                .Take(take)
                .Select(e => new InfaqForGetManyRecord
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

    public async Task<GetManyResult<InfaqForGetManyDueRecord>> GetManyDueAsync(
        DateTime dueDateTime,
        IEnumerable<PaymentType>? paymentTypes = default,
        GetManyOrderBy getManyOrderBy = default,
        OrderByDirection orderByDirection = default,
        int skip = 0,
        int take = 1)
    {
        var queryable = _dbSet.Where(e => (e.PaymentStatus == PaymentStatus.Pending) && (e.DateTime < dueDateTime));

        if (paymentTypes != default)
            queryable = queryable.Where(e => paymentTypes.Any(s => s == e.PaymentType));


        var countTask = queryable.LongCountAsync();


        if (getManyOrderBy == GetManyOrderBy.Id)
        {
            if (orderByDirection == OrderByDirection.Descending) queryable = queryable.OrderByDescending(e => e.Id);
            else queryable = queryable.OrderBy(e => e.Id);
        }


        var count = await countTask;

        return new()
        {
            Records = await queryable.Skip(skip)
                .Take(take)
                .Select(e => new InfaqForGetManyDueRecord
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

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<InfaqForGetOne?> GetOneAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new InfaqForGetOne
            {
                Amount = e.Amount,
                DateTime = e.DateTime,
                MunfiqName = e.MunfiqName,
                PaymentStatus = e.PaymentStatus,
                PaymentType = e.PaymentType,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<InfaqForGetOneDue?> GetOneDueAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new InfaqForGetOneDue
            {
                Amount = e.Amount,
                DateTime = e.DateTime,
                MunfiqName = e.MunfiqName,
                PaymentType = e.PaymentType,
            })
            .FirstOrDefaultAsync();
    }


    private async Task<int> SaveAsync()
    {
        return await _infaqsDataContext.SaveChangesAsync();
    }


    public void UpdatePaymentStatus(int id, PaymentStatus paymentStatus)
    {
        var infaq = new Infaq
        {
            Id = id,
            PaymentStatus = paymentStatus,
        };

        _dbSet.Attach(infaq)
            .Property(e => e.PaymentStatus)
            .IsModified = true;
    }
}
