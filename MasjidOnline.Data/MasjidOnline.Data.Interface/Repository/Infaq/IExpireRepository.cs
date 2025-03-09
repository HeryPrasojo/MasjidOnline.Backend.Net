using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Expire;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IExpireRepository
{
    Task AddAsync(Expire expire);
    Task<bool> AnyAsync(int infaqId, ExpireStatus status);
    Task<ForSetStatus?> GetForSetStatusAsync(int id);
    Task<ManyResult<ManyRecord>> GetManyAsync(ExpireStatus? status = ExpireStatus.Invalid, ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<ManyResult<ManyNewRecord>> GetManyNewAsync(ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<int> GetMaxIdAsync();
    Task<One?> GetOneAsync(int infaqId);
    //Task<ExpireStatus> GetStatusAsync(int id);
    void SetStatus(int id, ExpireStatus status, string? description, DateTime updateDateTime, int updateUserId);
}
