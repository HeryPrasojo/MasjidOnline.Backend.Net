using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IAuditIdGenerator
{
    int PermissionLogId { get; }

    Task InitializeAsync(IData data);
}
