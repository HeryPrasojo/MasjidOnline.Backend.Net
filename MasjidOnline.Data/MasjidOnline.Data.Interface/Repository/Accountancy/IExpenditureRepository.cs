using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Accountancy.Expenditure;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Accountancy;

namespace MasjidOnline.Data.Interface.Repository.Accountancy;

public interface IExpenditureRepository
{
    Task AddAndSaveAsync(Expenditure expenditure);
    Task<ForApprove?> GetForApproveAsync(int id);
    Task<ManyResult<ManyRecord>> GetManyAsync(ExpenditureStatus? status = null, ManyOrderBy getManyOrderBy = default, OrderByDirection orderByDirection = default, int skip = 0, int take = 1);
    Task<int> GetMaxIdAsync();
    Task<One?> GetOneAsync(int id);
    Task<ExpenditureStatus> GetStatusAsync(int id);
    Task SetStatusAndSaveAsync(int id, ExpenditureStatus status, string? statusDescription, DateTime updateDateTime, int updateUserId);
}
