using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Data.Interface.Model.User.Internal;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IInternalRepository
{
    Task AddAsync(Internal @internal);
    Task<GetManyResult<GetManyRecord>> GetManyAsync(bool? isApproved = null, GetManyOrderBy getManyOrderBy = GetManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<int> GetMaxIdAsync();
}
