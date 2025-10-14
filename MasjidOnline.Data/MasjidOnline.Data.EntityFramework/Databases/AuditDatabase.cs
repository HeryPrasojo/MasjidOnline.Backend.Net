using MasjidOnline.Data.EntityFramework.Repository.Audit;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class AuditDatabase(DbContext _dbContext) : Database(_dbContext), IAuditDatabase
{
    private IAuditSettingRepository? _auditSettingRepository;
    private IUserLogRepository? _userLogRepository;
    private IUserEmailAddressLogRepository? _userEmailAddressLogRepository;
    private IUserInternalPermissionLogRepository? _userInternalPermissionLogRepository;

    public IAuditSettingRepository AuditSetting => _auditSettingRepository ??= new AuditSettingRepository(_dbContext);

    public IUserLogRepository UserLog => _userLogRepository ??= new UserLogRepository(_dbContext);

    public IUserEmailAddressLogRepository UserEmailAddressLog => _userEmailAddressLogRepository ??= new UserEmailAddressLogRepository(_dbContext);

    public IUserInternalPermissionLogRepository UserInternalPermissionLog => _userInternalPermissionLogRepository ??= new UserInternalPermissionLogRepository(_dbContext);
}