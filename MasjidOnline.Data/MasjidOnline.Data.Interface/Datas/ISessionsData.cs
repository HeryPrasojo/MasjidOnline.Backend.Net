using MasjidOnline.Data.Interface.Repository.Sessions;

namespace MasjidOnline.Data.Interface.Datas;

public interface ISessionsData : IDataWithoutAudit
{
    ISessionRepository Session { get; }
    ISessionSettingRepository SessionSetting { get; }
}
