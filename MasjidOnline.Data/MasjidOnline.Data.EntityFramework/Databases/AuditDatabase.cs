using MasjidOnline.Data.EntityFramework.Repository.Audit;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class AuditDatabase(DbContext _dbContext) : Database(_dbContext), IAuditDatabase
{
    private IAuditSettingRepository? _auditSettingRepository;
    private IPersonLogRepository? _personLogRepository;
    private IUserLogRepository? _userLogRepository;
    private IUserDataLogRepository? _userDataLogRepository;
    private IUserEmailLogRepository? _userEmailLogRepository;
    private IUserInternalPermissionLogRepository? _userInternalPermissionLogRepository;

    public IAuditSettingRepository AuditSetting => _auditSettingRepository ??= new AuditSettingRepository(_dbContext);

    public IPersonLogRepository PersonLog => _personLogRepository ??= new PersonLogRepository(_dbContext);

    public IUserLogRepository UserLog => _userLogRepository ??= new UserLogRepository(_dbContext);

    public IUserDataLogRepository UserDataLog => _userDataLogRepository ??= new UserDataLogRepository(_dbContext);

    public IUserEmailLogRepository UserEmailLog => _userEmailLogRepository ??= new UserEmailLogRepository(_dbContext);

    public IUserInternalPermissionLogRepository UserInternalPermissionLog => _userInternalPermissionLogRepository ??= new UserInternalPermissionLogRepository(_dbContext);
}