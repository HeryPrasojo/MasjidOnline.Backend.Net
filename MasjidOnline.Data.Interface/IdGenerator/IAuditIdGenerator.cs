namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IAuditIdGenerator
{
    int UserLogId { get; }
    int UserEmailAddressLogId { get; }
}
