using System;
using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IPermissionLogRepository
{
    Task AddAddAsync(Permission permission, DateTime dateTime, int userId);
    Task<int> GetMaxPermissionLogIdAsync();
}
