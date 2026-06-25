using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Donation;
using MasjidOnline.Data.Interface.ViewModel.Donation.Donation;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Donation;
using MasjidOnline.Entity.Payment;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Donation;

public class DonationRepository(DbContext _dbContext) : IDonationRepository
{
    private readonly DbSet<Entity.Donation.Donation> _dbSet = _dbContext.Set<Entity.Donation.Donation>();

    public async Task AddAsync(Entity.Donation.Donation Donation)
    {
        await _dbSet.AddAsync(Donation);
    }

    public async Task<ExpireAdd?> GetForExpireAddAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new ExpireAdd
            {
                DateTime = e.DateTime,
                Status = e.Status,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<SuccessAdd?> GetForSuccessAddAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new SuccessAdd
            {
                DateTime = e.DateTime,
                Status = e.Status,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<VoidAdd?> GetForVoidAddAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new VoidAdd
            {
                DateTime = e.DateTime,
                Status = e.Status,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<TableResult<TableRecord>> GetTableAsync(
        IEnumerable<PaymentType>? paymentTypes = default,
        IEnumerable<DonationStatus>? paymentStatuses = default,
        int skip = 0,
        int take = 1)
    {
        var queryable = _dbSet.AsQueryable();

        if (paymentStatuses != default)
            queryable = queryable.Where(e => paymentStatuses.Any(s => s == e.Status));

        if (paymentTypes != default)
            queryable = queryable.Where(e => paymentTypes.Any(s => s == e.PaymentType));


        var countTask = queryable.LongCountAsync();


        queryable = queryable.OrderByDescending(e => e.Id);

        return new()
        {
            Records = await queryable.Skip(skip)
                .Take(take)
                .Select(e => new TableRecord
                {
                    Amount = e.Amount,
                    DateTime = e.DateTime,
                    Id = e.Id,
                    MunfiqName = e.MunfiqName,
                    Status = e.Status,
                    PaymentType = e.PaymentType,
                })
                .ToArrayAsync(),
            RecordCount = await countTask,
        };
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<View?> GetFirstOrDefaultAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new View
            {
                Amount = e.Amount,
                DateTime = e.DateTime,
                MunfiqName = e.MunfiqName,
                PaymentType = e.PaymentType,
                Status = e.Status,
            })
            .FirstOrDefaultAsync();
    }


    public void SetStatus(int id, DonationStatus paymentStatus)
    {
        var Donation = new Entity.Donation.Donation
        {
            Id = id,
            Status = paymentStatus,
        };

        _dbSet.Attach(Donation)
            .Property(e => e.Status)
            .IsModified = true;
    }
}



