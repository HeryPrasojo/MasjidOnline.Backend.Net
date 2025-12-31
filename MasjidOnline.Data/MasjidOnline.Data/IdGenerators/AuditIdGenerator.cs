using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class AuditIdGenerator : IAuditIdGenerator
{
    private int _permissionLogId;
    private int _personLogId;
    private int _userLogId;
    private int _userDataLogId;
    private int _userEmailLogId;

    public async Task InitializeAsync(IData data)
    {
        _permissionLogId = await data.Audit.UserInternalPermissionLog.GetMaxIdAsync();
        _personLogId = await data.Audit.PersonLog.GetMaxIdAsync();
        _userLogId = await data.Audit.UserLog.GetMaxIdAsync();
        _userDataLogId = await data.Audit.UserDataLog.GetMaxIdAsync();
        _userEmailLogId = await data.Audit.UserEmailLog.GetMaxIdAsync();
    }

    public int PermissionLogId => Interlocked.Increment(ref _permissionLogId);

    public int PersonLogId => Interlocked.Increment(ref _userLogId);

    public int UserLogId => Interlocked.Increment(ref _userLogId);

    public int UserDataLogId => Interlocked.Increment(ref _userDataLogId);

    public int UserEmailLogId => Interlocked.Increment(ref _userEmailLogId);
}
