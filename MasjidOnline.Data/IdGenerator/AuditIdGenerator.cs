using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class AuditIdGenerator : IAuditIdGenerator
{
    private int _userLogId;
    private int _userEmailAddressLogId;

    public async Task InitializeAsync(IAuditData auditData)
    {
        _userLogId = await auditData.UserLog.GetMaxIdAsync();

        _userEmailAddressLogId = await auditData.UserEmailAddressLog.GetMaxIdAsync();
    }

    public int UserLogId => Interlocked.Increment(ref _userLogId);

    public int UserEmailAddressLogId => Interlocked.Increment(ref _userEmailAddressLogId);
}
