using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Audit;

namespace MasjidOnline.Data.Interface.Datas;

public interface IAuditData : IData
{
    IAuditSettingRepository AuditSetting { get; }

    Task AddAsync(IEnumerable<object> auditEntities);
    IUserLogRepository UserLog { get; }
    IUserEmailAddressLogRepository UserEmailAddressLog { get; }
}
