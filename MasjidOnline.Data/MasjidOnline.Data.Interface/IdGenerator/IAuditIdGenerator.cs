using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IAuditIdGenerator
{
    int UserLogId { get; }
    int UserEmailAddressLogId { get; }
    int PermissionLogId { get; }

    Task InitializeAsync(IAuditData auditData);
}
