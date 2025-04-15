using System;
using System.Threading.Tasks;
using MasjidOnline.Entity.Accountancy;

namespace MasjidOnline.Data.Interface.Repository.Accountancy;

public interface IExpenditureRepository
{
    Task AddAddAsync(Expenditure expenditure, DateTime dateTime, int userId);
    Task<int> GetMaxExpenditureIdAsync();
}
