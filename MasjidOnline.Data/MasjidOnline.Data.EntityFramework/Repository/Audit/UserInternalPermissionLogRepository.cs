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
        var userInternalPermissionLog = new UserInternalPermissionLog
        {
            Id = id,
            LogDateTime = dateTime,
            LogType = UserInternalPermissionLogType.Add,
            LogUserId = logUserId,

            UserId = userInternalPermission.UserId,
            AccountancyExpenditureAdd = userInternalPermission.AccountancyExpenditureAdd,
            AccountancyExpenditureApprove = userInternalPermission.AccountancyExpenditureApprove,
            InfaqExpireAdd = userInternalPermission.InfaqExpireAdd,
            InfaqExpireApprove = userInternalPermission.InfaqExpireApprove,
            InfaqSuccessAdd = userInternalPermission.InfaqSuccessAdd,
            InfaqSuccessApprove = userInternalPermission.InfaqSuccessApprove,
            InfaqVoidAdd = userInternalPermission.InfaqVoidAdd,
            InfaqVoidApprove = userInternalPermission.InfaqVoidApprove,
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
