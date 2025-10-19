using System;
using System.Threading.Tasks;
using MasjidOnline.Entity.Authorization;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IUserInternalPermissionLogRepository
{
    Task AddAddAsync(int id, DateTime dateTime, int logUserId, UserInternalPermission userInternalPermission);
    Task<int> GetMaxIdAsync();
}
