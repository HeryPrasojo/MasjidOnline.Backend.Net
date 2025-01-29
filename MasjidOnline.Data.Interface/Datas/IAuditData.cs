using MasjidOnline.Data.Interface.Repository.Audit;

namespace MasjidOnline.Data.Interface.Datas;

public interface IAuditData : IData
{
    IAuditSettingRepository AuditSetting { get; }

    IUserLogRepository UserLog { get; }
    IUserEmailAddressLogRepository UserEmailAddressLog { get; }
}
