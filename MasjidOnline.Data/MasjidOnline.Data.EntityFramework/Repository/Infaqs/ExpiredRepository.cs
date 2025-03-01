using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.Infaqs.Expired;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Data.Interface.Repository.Infaqs;
using MasjidOnline.Entity.Infaqs;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaqs;

public class ExpiredRepository(InfaqsDataContext _infaqsDataContext) : IExpiredRepository
{
    private readonly DbSet<Expired> _dbSet = _infaqsDataContext.Set<Expired>();

    public async Task AddAsync(Expired expired)
    {
        await _dbSet.AddAsync(expired);
    }

    public async Task<GetManyResult<GetManyRecord>> GetManyAsync(
        bool? isApproved = default,
        GetManyOrderBy getManyOrderBy = default,
        OrderByDirection orderByDirection = default,
        int skip = 0,
        int take = 1)
    {
        var queryable = _dbSet.AsQueryable();

        if (isApproved != default)
            queryable = queryable.Where(e => e.IsApproved == isApproved);


        var countTask = queryable.LongCountAsync();


        if (getManyOrderBy == GetManyOrderBy.DateTime)
        {
            if (orderByDirection == OrderByDirection.Descending) queryable = queryable.OrderByDescending(e => e.DateTime);
            else queryable = queryable.OrderBy(e => e.DateTime);
        }


        var count = await countTask;

        return new()
        {
            Records = await queryable.Skip(skip)
                .Take(take)
                .Select(e => new GetManyRecord
                {
                    DateTime = e.DateTime,
                    InfaqId = e.InfaqId,
                    IsApproved = e.IsApproved,
                    UpdateDateTime = e.UpdateDateTime,
                    UpdateUserId = e.UpdateUserId,
                    UserId = e.UserId,
                })
                .ToArrayAsync(),
            Total = count,
        };
    }

    public async Task<GetOne?> GetOneAsync(int infaqId)
    {
        return await _dbSet.Where(e => e.InfaqId == infaqId)
            .Select(e => new GetOne
            {
                DateTime = e.DateTime,
                InfaqId = e.InfaqId,
                IsApproved = e.IsApproved,
                UpdateDateTime = e.UpdateDateTime,
                UpdateUserId = e.UpdateUserId,
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }
}
