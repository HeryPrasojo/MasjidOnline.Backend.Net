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
    Task<TableResult<TableRecord>> GetTableAsync(ExpenditureStatus? status = null, TableOrderBy getTableOrderBy = default, OrderByDirection orderByDirection = default, int skip = 0, int take = 1);
    Task<int> GetMaxIdAsync();
    Task<View?> GetFirstOrDefaultAsync(int id);
    Task<ExpenditureStatus> GetStatusAsync(int id);
    Task SetStatusAndSaveAsync(int id, ExpenditureStatus status, string? statusDescription, DateTime updateDateTime, int updateUserId);
}
