using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Infaq.Expired;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IExpiredRepository
{
    Task AddAsync(Expired expired);
    Task<ManyResult<ManyRecord>> GetManyAsync(bool? isApproved = null, ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<ManyResult<ManyUnprovedRecord>> GetManyUnprovedAsync(ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<One?> GetOneAsync(int infaqId);
}
