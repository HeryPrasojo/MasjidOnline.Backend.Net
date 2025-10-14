using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class AuditIdGenerator : IAuditIdGenerator
{
    private int _permissionLogId;
    private int _userLogId;
    private int _userEmailAddressLogId;

    public async Task InitializeAsync(IData data)
    {
        _permissionLogId = await data.Audit.UserInternalPermissionLog.GetMaxIdAsync();
        _userLogId = await data.Audit.UserLog.GetMaxIdAsync();
        _userEmailAddressLogId = await data.Audit.UserEmailAddressLog.GetMaxIdAsync();
    }

    public int PermissionLogId => Interlocked.Increment(ref _permissionLogId);

    public int UserLogId => Interlocked.Increment(ref _userLogId);

    public int UserEmailAddressLogId => Interlocked.Increment(ref _userEmailAddressLogId);
}
