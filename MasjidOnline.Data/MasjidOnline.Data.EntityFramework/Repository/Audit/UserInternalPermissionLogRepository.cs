using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using MasjidOnline.Entity.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class UserInternalPermissionLogRepository(DbContext _dbContext) : IUserInternalPermissionLogRepository
{
    private readonly DbSet<UserInternalPermissionLog> _dbSet = _dbContext.Set<UserInternalPermissionLog>();

    public async Task AddAddAsync(int id, DateTime dateTime, int logUserId, UserInternalPermission userInternalPermission)
    {
        await AddAsync(id, dateTime, UserInternalPermissionLogType.Add, logUserId, userInternalPermission);
    }

    public async Task AddUpdateAsync(int id, DateTime dateTime, int logUserId, UserInternalPermission userInternalPermission)
    {
        await AddAsync(id, dateTime, UserInternalPermissionLogType.Update, logUserId, userInternalPermission);
    }

    private async Task AddAsync(
        int id,
        DateTime dateTime,
        UserInternalPermissionLogType userInternalPermissionLogType,
        int logUserId,
        UserInternalPermission userInternalPermission)
    {
        var userInternalPermissionLog = new UserInternalPermissionLog
        {
            Id = id,
            LogDateTime = dateTime,
            LogType = userInternalPermissionLogType,
            LogUserId = logUserId,

            UserId = userInternalPermission.UserId,
            AccountancyExpenditureAdd = userInternalPermission.AccountancyExpenditureAdd,
            AccountancyExpenditureApprove = userInternalPermission.AccountancyExpenditureApprove,
            InfaqStatusApprove = userInternalPermission.InfaqStatusApprove,
            InfaqStatusRequest = userInternalPermission.InfaqStatusRequest,
            UserInternalAdd = userInternalPermission.UserInternalAdd,
            UserInternalApprove = userInternalPermission.UserInternalApprove,
            UserInternalPermissionUpdate = userInternalPermission.UserInternalPermissionUpdate,
        };

        await _dbSet.AddAsync(userInternalPermissionLog);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
