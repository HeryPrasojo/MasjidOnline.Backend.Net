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
    Task<ManyResult<ManyRecord>> GetManyAsync(ExpireStatus? status = default, int skip = 0, int take = 1);
    Task<int> GetMaxIdAsync();
    Task<One?> GetOneAsync(int id);

    //Task<ExpireStatus> GetStatusAsync(int id);
    void SetStatus(int id, ExpireStatus status, string? description, DateTime updateDateTime, int updateUserId);
}
