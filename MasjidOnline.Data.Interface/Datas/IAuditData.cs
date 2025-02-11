using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Audit;

namespace MasjidOnline.Data.Interface.Datas;

public interface IAuditData : IData
{
    IAuditSettingRepository AuditSetting { get; }

    IPermissionLogRepository PermissionLog { get; }
    IUserLogRepository UserLog { get; }
    IUserEmailAddressLogRepository UserEmailAddressLog { get; }

    Task AddAsync(IEnumerable<object> entities);
}
