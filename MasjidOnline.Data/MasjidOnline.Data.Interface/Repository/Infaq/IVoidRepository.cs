using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Void;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IVoidRepository
{
    Task AddAsync(Entity.Infaq.Void @void);
    Task<bool> AnyAsync(int infaqId, VoidStatus status);
    Task<ForSetStatus?> GetForSetStatusAsync(int id);
    Task<ManyResult<ManyRecord>> GetManyAsync(VoidStatus? status = null, ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<ManyResult<ManyNewRecord>> GetManyNewAsync(ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<int> GetMaxIdAsync();
    Task<One?> GetOneAsync(int id);
    void SetStatus(int id, VoidStatus status, string? description, DateTime updateDateTime, int updateUserId);
}
