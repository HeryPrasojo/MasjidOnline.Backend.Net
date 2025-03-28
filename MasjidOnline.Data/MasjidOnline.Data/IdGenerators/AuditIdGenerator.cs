using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class AuditIdGenerator : IAuditIdGenerator
{
    private int _permissionLogId;

    public async Task InitializeAsync(IData data)
    {
        _permissionLogId = await data.Audit.PermissionLog.GetMaxPermissionLogIdAsync();
    }

    public int PermissionLogId => Interlocked.Increment(ref _permissionLogId);
}
