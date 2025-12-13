using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Success;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface ISuccessRepository
{
    Task AddAsync(Success success);
    Task<bool> AnyAsync(int infaqId, SuccessStatus status);
    Task<ForSetStatus?> GetForSetStatusAsync(int id);
    Task<ManyResult<ManyRecord>> GetManyAsync(SuccessStatus? status = null, ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = default, int skip = 0, int take = 1);
    Task<int> GetMaxIdAsync();
    Task<One?> GetOneAsync(int id);
    void SetStatus(int id, SuccessStatus status, string? description, DateTime updateDateTime, int updateUserId);
}
