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
                    EmailAddress = e.EmailAddress,
                    Id = e.Id,
                    IsApproved = e.IsApproved,
                    UpdateDateTime = e.UpdateDateTime,
                    UpdateUserId = e.UpdateUserId,
                    UserId = e.UserId,
                })
                .ToArrayAsync(),
            Total = count,
        };
    }
}
