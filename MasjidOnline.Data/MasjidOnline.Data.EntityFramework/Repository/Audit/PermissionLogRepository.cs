using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class PermissionLogRepository(AuditDataContext _auditDataContext, IAuditIdGenerator _auditIdGenerator) : IPermissionLogRepository
{
    private readonly DbSet<PermissionLog> _dbSet = _auditDataContext.Set<PermissionLog>();

    public async Task AddAddAsync(Permission permission, DateTime dateTime, int userId)
    {
        var permissionLog = new PermissionLog
        {
            Id = _auditIdGenerator.PermissionLogId,
            LogDateTime = dateTime,
            LogType = PermissionLogType.Add,
            LogUserId = userId,

            UserId = permission.UserId,
            InfaqExpireAdd = permission.InfaqExpireAdd,
            InfaqExpireApprove = permission.InfaqExpireApprove,
            InfaqExpireCancel = permission.InfaqExpireCancel,
            InfaqSuccessAdd = permission.InfaqSuccessAdd,
            InfaqSuccessApprove = permission.InfaqSuccessApprove,
            InfaqSuccessCancel = permission.InfaqSuccessCancel,
            InfaqVoidAdd = permission.InfaqVoidAdd,
            InfaqVoidApprove = permission.InfaqVoidApprove,
            InfaqVoidCancel = permission.InfaqVoidCancel,
            UserInternalAdd = permission.UserInternalAdd,
            UserInternalApprove = permission.UserInternalApprove,
            UserInternalCancel = permission.UserInternalCancel,
        };

        await _dbSet.AddAsync(permissionLog);
    }

    public async Task<int> GetMaxPermissionLogIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
