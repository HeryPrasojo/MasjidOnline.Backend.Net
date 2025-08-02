using MasjidOnline.Data.EntityFramework.Repository.Audit;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Repository.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class AuditDatabase(
    DbContext _dbContext,
    IAuditIdGenerator _auditIdGenerator) : Database(_dbContext), IAuditDatabase
{
    private IAuditSettingRepository? _auditSettingRepository;
    private IUserInternalPermissionLogRepository? _userInternalPermissionLogRepository;

    public IAuditSettingRepository AuditSetting => _auditSettingRepository ??= new AuditSettingRepository(_dbContext);
    public IUserInternalPermissionLogRepository UserInternalPermissionLog => _userInternalPermissionLogRepository ??= new UserInternalPermissionLogRepository(_dbContext, _auditIdGenerator);
}