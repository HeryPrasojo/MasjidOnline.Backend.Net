using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Audit;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Data.Mapper;
using MasjidOnline.Entity.Audit;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Datas;
// todo change ISessionBusiness dependency to userId via method parameter
public class AuditData(
    AuditDataContext _auditDataContext,
    IAuditIdGenerator _auditIdGenerator,
    ISessionBusiness _sessionBusiness) : DataWithoutAudit(_auditDataContext), IAuditData
{
    private DbSet<PermissionLog>? _permissionLogDbSet;
    private DbSet<UserLog>? _userLogDbSet;
    private DbSet<UserEmailAddressLog>? _userEmailAddressLogDbSet;

    private IAuditSettingRepository? _auditSettingRepository;
    private IPermissionLogRepository? _permissionLogRepository;
    private IUserEmailAddressLogRepository? _userEmailAddressLogRepository;
    private IUserLogRepository? _userLogRepository;

    public IAuditSettingRepository AuditSetting => _auditSettingRepository ??= new AuditSettingRepository(_auditDataContext);
    public IPermissionLogRepository PermissionLog => _permissionLogRepository ??= new PermissionLogRepository(_auditDataContext);
    public IUserEmailAddressLogRepository UserEmailAddressLog => _userEmailAddressLogRepository ??= new UserEmailAddressLogRepository(_auditDataContext);
    public IUserLogRepository UserLog => _userLogRepository ??= new UserLogRepository(_auditDataContext);

    public async Task AddAsync(IEnumerable<object> entities)
    {
        var utcNow = DateTime.UtcNow;

        foreach (var entity in entities)
        {
            if (entity is User user)
            {
                _userLogDbSet ??= _auditDataContext.Set<UserLog>();

                var userLog = user.MapUserLog(_auditIdGenerator.UserLogId, _sessionBusiness.UserId, utcNow);

                await _userLogDbSet.AddAsync(userLog);
            }
            else if (entity is UserEmailAddress userEmailAddress)
            {
                _userEmailAddressLogDbSet ??= _auditDataContext.Set<UserEmailAddressLog>();

                var userEmailAddressLog = userEmailAddress.MapUserEmailAddressLog(_auditIdGenerator.UserEmailAddressLogId, _sessionBusiness.UserId, utcNow);

                await _userEmailAddressLogDbSet.AddAsync(userEmailAddressLog);
            }
            else if (entity is Permission permission)
            {
                _permissionLogDbSet ??= _auditDataContext.Set<PermissionLog>();

                var permissionLog = permission.MapPermissionLog(_auditIdGenerator.PermissionLogId, _sessionBusiness.UserId, utcNow);

                await _permissionLogDbSet.AddAsync(permissionLog);
            }
        }
    }
}