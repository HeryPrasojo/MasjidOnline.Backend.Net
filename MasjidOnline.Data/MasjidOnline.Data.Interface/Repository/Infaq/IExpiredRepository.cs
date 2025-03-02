using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Infaq.Expired;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IExpiredRepository
{
    Task AddAsync(Expired expired);
    Task<GetManyResult<GetManyRecord>> GetManyAsync(bool? isApproved = null, GetManyOrderBy getManyOrderBy = GetManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<GetManyResult<GetManyUnprovedRecord>> GetManyUnprovedAsync(GetManyOrderBy getManyOrderBy = GetManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<GetOne?> GetOneAsync(int infaqId);
}
