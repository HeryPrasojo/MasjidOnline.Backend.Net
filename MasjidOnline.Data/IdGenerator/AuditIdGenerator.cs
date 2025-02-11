using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class AuditIdGenerator : IAuditIdGenerator
{
    private int _permissionLogId;
    private int _userLogId;
    private int _userEmailAddressLogId;

    public async Task InitializeAsync(IAuditData auditData)
    {
        _permissionLogId = await auditData.PermissionLog.GetMaxPermissionLogIdAsync();

        _userLogId = await auditData.UserLog.GetMaxUserLogIdAsync();

        _userEmailAddressLogId = await auditData.UserEmailAddressLog.GetMaxUserEmailAddressLogIdAsync();
    }

    public int PermissionLogId => Interlocked.Increment(ref _permissionLogId);

    public int UserLogId => Interlocked.Increment(ref _userLogId);

    public int UserEmailAddressLogId => Interlocked.Increment(ref _userEmailAddressLogId);
}
