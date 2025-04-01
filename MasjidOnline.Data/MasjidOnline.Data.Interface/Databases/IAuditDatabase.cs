using MasjidOnline.Data.Interface.Repository.Audit;

namespace MasjidOnline.Data.Interface.Databases;

public interface IAuditDatabase : IDatabase
{
    IAuditSettingRepository AuditSetting { get; }

    // todo rename to InternalPermission
    IUserInternalPermissionLogRepository UserInternalPermissionLog { get; }
}
