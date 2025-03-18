using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class AuditIdGenerator : IAuditIdGenerator
{
    private int _permissionLogId;

    public async Task InitializeAsync(IAuditData auditData)
    {
        _permissionLogId = await auditData.PermissionLog.GetMaxPermissionLogIdAsync();
    }

    public int PermissionLogId => Interlocked.Increment(ref _permissionLogId);
}
