using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Infaqs.Expired;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Interface.Repository.Infaqs;

public interface IExpiredRepository
{
    Task AddAsync(Expired expired);
    Task<GetManyResult<GetManyRecord>> GetManyAsync(bool? isApproved = null, GetManyOrderBy getManyOrderBy = GetManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<GetOne?> GetOneAsync(int infaqId);
}
