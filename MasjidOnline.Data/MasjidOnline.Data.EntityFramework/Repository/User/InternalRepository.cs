using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Data.Interface.Model.User.Internal;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class InternalRepository(UserDataContext _userDataContext) : IInternalRepository
{
    private readonly DbSet<Internal> _dbSet = _userDataContext.Set<Internal>();

    public async Task AddAsync(Internal @internal)
    {
        await _dbSet.AddAsync(@internal);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<ManyResult<ManyRecord>> GetManyAsync(
        InternalStatus status = default,
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
                    EmailAddress = e.EmailAddress,
                    Id = e.Id,
                    Status = e.Status,
                    UpdateDateTime = e.UpdateDateTime,
                    UpdateUserId = e.UpdateUserId,
                    UserId = e.UserId,
                })
                .ToArrayAsync(),
            Total = count,
        };
    }

    public async Task<One?> GetOneAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new One
            {
                DateTime = e.DateTime,
                EmailAddress = e.EmailAddress,
                Status = e.Status,
                UpdateDateTime = e.UpdateDateTime,
                UpdateUserId = e.UpdateUserId,
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<InternalStatus> GetStatusAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => e.Status)
            .FirstOrDefaultAsync();
    }
}
