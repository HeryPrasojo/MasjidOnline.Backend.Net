using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Audit;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Repository.Audit;

namespace MasjidOnline.Data.EntityFramework.Databases;

// todo low change *DataContext to DbContext
public class AuditDatabase(
    AuditDataContext _auditDataContext,
    IAuditIdGenerator _auditIdGenerator) : Database(_auditDataContext), IAuditDatabase
{
    private IAuditSettingRepository? _auditSettingRepository;
    private IUserInternalPermissionLogRepository? _userInternalPermissionLogRepository;

    public IAuditSettingRepository AuditSetting => _auditSettingRepository ??= new AuditSettingRepository(_auditDataContext);
    public IUserInternalPermissionLogRepository UserInternalPermissionLog => _userInternalPermissionLogRepository ??= new UserInternalPermissionLogRepository(_auditDataContext, _auditIdGenerator);
}