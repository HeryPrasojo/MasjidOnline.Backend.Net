using MasjidOnline.Data.Interface.Repository.Session;

namespace MasjidOnline.Data.Interface.Datas;

public interface ISessionData : IDataWithoutAudit
{
    ISessionRepository Session { get; }
    ISessionSettingRepository SessionSetting { get; }
}
