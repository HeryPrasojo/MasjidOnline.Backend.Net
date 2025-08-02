using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using MasjidOnline.Entity.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class UserInternalPermissionLogRepository(DbContext _dbContext, IAuditIdGenerator _auditIdGenerator) : IUserInternalPermissionLogRepository
{
    private readonly DbSet<UserInternalPermissionLog> _dbSet = _dbContext.Set<UserInternalPermissionLog>();

    public async Task AddAddAsync(UserInternalPermission userInternalPermission, DateTime dateTime, int userId)
    {
        var userInternalPermissionLog = new UserInternalPermissionLog
        {
            Id = _auditIdGenerator.PermissionLogId,
            LogDateTime = dateTime,
            LogType = UserInternalPermissionLogType.Add,
            LogUserId = userId,

            UserId = userInternalPermission.UserId,
            AccountancyExpenditureAdd = userInternalPermission.AccountancyExpenditureAdd,
            AccountancyExpenditureApprove = userInternalPermission.AccountancyExpenditureApprove,
            AccountancyExpenditureCancel = userInternalPermission.AccountancyExpenditureCancel,
            InfaqExpireAdd = userInternalPermission.InfaqExpireAdd,
            InfaqExpireApprove = userInternalPermission.InfaqExpireApprove,
            InfaqExpireCancel = userInternalPermission.InfaqExpireCancel,
            InfaqSuccessAdd = userInternalPermission.InfaqSuccessAdd,
            InfaqSuccessApprove = userInternalPermission.InfaqSuccessApprove,
            InfaqSuccessCancel = userInternalPermission.InfaqSuccessCancel,
            InfaqVoidAdd = userInternalPermission.InfaqVoidAdd,
            InfaqVoidApprove = userInternalPermission.InfaqVoidApprove,
            InfaqVoidCancel = userInternalPermission.InfaqVoidCancel,
            UserInternalAdd = userInternalPermission.UserInternalAdd,
            UserInternalApprove = userInternalPermission.UserInternalApprove,
            UserInternalCancel = userInternalPermission.UserInternalCancel,
        };

        await _dbSet.AddAsync(userInternalPermissionLog);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
