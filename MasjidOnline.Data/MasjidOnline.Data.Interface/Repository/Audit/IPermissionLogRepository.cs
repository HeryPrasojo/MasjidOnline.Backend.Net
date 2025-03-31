using System;
using System.Threading.Tasks;
using MasjidOnline.Entity.Authorization;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IPermissionLogRepository
{
    Task AddAddAsync(InternalPermission permission, DateTime dateTime, int userId);
    Task<int> GetMaxPermissionLogIdAsync();
}
