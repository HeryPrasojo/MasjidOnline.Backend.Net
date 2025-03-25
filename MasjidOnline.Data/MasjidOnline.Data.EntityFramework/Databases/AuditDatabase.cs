using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Audit;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Repository.Audit;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class AuditDatabase(
    AuditDataContext _auditDataContext,
    IAuditIdGenerator _auditIdGenerator) : Database(_auditDataContext), IAuditDatabase
{
    private IAuditSettingRepository? _auditSettingRepository;
    private IPermissionLogRepository? _permissionLogRepository;

    public IAuditSettingRepository AuditSetting => _auditSettingRepository ??= new AuditSettingRepository(_auditDataContext);
    public IPermissionLogRepository PermissionLog => _permissionLogRepository ??= new PermissionLogRepository(_auditDataContext, _auditIdGenerator);
}