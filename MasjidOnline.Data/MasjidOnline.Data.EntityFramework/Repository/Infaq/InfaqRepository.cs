using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Infaq;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Payment;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class InfaqRepository(InfaqDataContext _infaqDataContext) : IInfaqRepository
{
    private readonly DbSet<Entity.Infaq.Infaq> _dbSet = _infaqDataContext.Set<Entity.Infaq.Infaq>();

    public async Task AddAsync(Entity.Infaq.Infaq infaq)
    {
        await _dbSet.AddAsync(infaq);
    }

    public async Task<ExpireAdd?> GetForExpireAddAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new ExpireAdd
            {
                DateTime = e.DateTime,
                PaymentStatus = e.PaymentStatus,
                PaymentType = e.PaymentType,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<SuccessAdd?> GetForSuccessAddAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new SuccessAdd
            {
                DateTime = e.DateTime,
                PaymentStatus = e.PaymentStatus,
                PaymentType = e.PaymentType,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<VoidAdd?> GetForVoidAddAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new VoidAdd
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
        int lastId = 0,
        int take = 1)
    {
        var queryable = _dbSet.Where(e => e.Id < lastId);

        if (paymentStatuses != default)
            queryable = queryable.Where(e => paymentStatuses.Any(s => s == e.PaymentStatus));

        if (paymentTypes != default)
            queryable = queryable.Where(e => paymentTypes.Any(s => s == e.PaymentType));


        var countTask = queryable.LongCountAsync();


        queryable = queryable.OrderByDescending(e => e.Id);

        return new()
        {
            Records = await queryable.Take(take)
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
            RecordCount = await countTask,
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


    public void SetPaymentStatus(int id, PaymentStatus paymentStatus)
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
