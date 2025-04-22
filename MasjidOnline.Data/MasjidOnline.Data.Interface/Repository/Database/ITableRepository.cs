using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Accountancy;
using MasjidOnline.Entity.Database;

namespace MasjidOnline.Data.Interface.Repository.Database;

public interface ITableRepository
{
    Task AddAsync(Table table);
    Task<int> GetMaxIdAsync();
}
