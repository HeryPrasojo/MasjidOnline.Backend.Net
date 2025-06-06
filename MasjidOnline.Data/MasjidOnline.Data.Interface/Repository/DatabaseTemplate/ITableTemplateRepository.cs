using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Accountancy;
using MasjidOnline.Entity.DatabaseTemplate;

namespace MasjidOnline.Data.Interface.Repository.DatabaseTemplate;

public interface ITableTemplateRepository
{
    Task AddAsync(TableTemplate table);
    Task<int> GetMaxIdAsync();
}
