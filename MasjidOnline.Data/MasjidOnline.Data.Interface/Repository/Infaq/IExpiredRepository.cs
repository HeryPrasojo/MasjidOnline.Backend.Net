using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Expired;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IExpiredRepository
{
    Task AddAsync(Expired expired);
    Task<bool> AnyAsync(int infaqId, ExpiredStatus status);
    Task<ForSetStatus?> GetForSetStatusAsync(int id);
    Task<ManyResult<ManyRecord>> GetManyAsync(ExpiredStatus? status = ExpiredStatus.Invalid, ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<ManyResult<ManyNewRecord>> GetManyNewAsync(ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<int> GetMaxIdAsync();
    Task<One?> GetOneAsync(int infaqId);
    //Task<ExpiredStatus> GetStatusAsync(int id);
    void SetStatus(int id, ExpiredStatus status, string? description, DateTime updateDateTime, int updateUserId);
}
