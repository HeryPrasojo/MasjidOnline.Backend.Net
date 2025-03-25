using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IAuditIdGenerator
{
    int PermissionLogId { get; }

    Task InitializeAsync(IAuditDatabase auditDatabase);
}
