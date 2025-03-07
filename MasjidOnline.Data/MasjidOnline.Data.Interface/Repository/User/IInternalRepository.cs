using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Data.Interface.Model.User.Internal;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IInternalRepository
{
    Task AddAndSaveAsync(Internal @internal);
    Task AddAsync(Internal @internal);
    Task<ManyResult<ManyRecord>> GetManyAsync(InternalStatus? status = default, ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<int> GetMaxIdAsync();
    Task<One?> GetOneAsync(int id);
    Task<InternalStatus> GetStatusAsync(int id);
    Task SetStatusAndSaveAsync(int id, InternalStatus status, string? description, DateTime updateDateTime, int updateUserId);
}
