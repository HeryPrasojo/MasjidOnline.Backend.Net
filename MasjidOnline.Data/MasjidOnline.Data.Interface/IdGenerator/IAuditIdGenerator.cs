namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IAuditIdGenerator
{
    int PermissionLogId { get; }
    int UserLogId { get; }
    int UserEmailLogId { get; }
    int UserDataLogId { get; }
}
