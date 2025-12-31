using MasjidOnline.Data.Interface.Repository.Audit;

namespace MasjidOnline.Data.Interface.Databases;

public interface IAuditDatabase : IDatabase
{
    IAuditSettingRepository AuditSetting { get; }

    IPersonLogRepository PersonLog { get; }

    IUserInternalPermissionLogRepository UserInternalPermissionLog { get; }
    IUserLogRepository UserLog { get; }
    IUserEmailLogRepository UserEmailLog { get; }
    IUserDataLogRepository UserDataLog { get; }
}
