namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IAuditIdGenerator
{
    int PermissionLogId { get; }
    int UserLogId { get; }
    int UserEmailAddressLogId { get; }
    int UserDataLogId { get; }
}
