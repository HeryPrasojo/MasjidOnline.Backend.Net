using System;
using System.Threading.Tasks;
using MasjidOnline.Entity.Authorization;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IUserInternalPermissionLogRepository
{
    Task AddAddAsync(UserInternalPermission userInternalPermission, int id, DateTime dateTime, int userId);
    Task<int> GetMaxIdAsync();
}
