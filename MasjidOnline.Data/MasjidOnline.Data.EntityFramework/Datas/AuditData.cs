using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Audit;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Data.Interface.Repository.Audit;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class AuditData(
    AuditDataContext _auditDataContext,
    IAuditIdGenerator _auditIdGenerator) : Data(_auditDataContext), IAuditDatabase
{
    private IAuditSettingRepository? _auditSettingRepository;
    private IPermissionLogRepository? _permissionLogRepository;

    public IAuditSettingRepository AuditSetting => _auditSettingRepository ??= new AuditSettingRepository(_auditDataContext);
    public IPermissionLogRepository PermissionLog => _permissionLogRepository ??= new PermissionLogRepository(_auditDataContext, _auditIdGenerator);
}