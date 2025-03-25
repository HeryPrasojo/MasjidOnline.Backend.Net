using MasjidOnline.Data.Interface.Repository.Audit;

namespace MasjidOnline.Data.Interface.Databases;

public interface IAuditDatabase : IDatabase
{
    IAuditSettingRepository AuditSetting { get; }

    IPermissionLogRepository PermissionLog { get; }
}
