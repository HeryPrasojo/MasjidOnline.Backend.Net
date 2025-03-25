using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class AuditIdGenerator : IAuditIdGenerator
{
    private int _permissionLogId;

    public async Task InitializeAsync(IAuditDatabase auditDatabase)
    {
        _permissionLogId = await auditDatabase.PermissionLog.GetMaxPermissionLogIdAsync();
    }

    public int PermissionLogId => Interlocked.Increment(ref _permissionLogId);
}
