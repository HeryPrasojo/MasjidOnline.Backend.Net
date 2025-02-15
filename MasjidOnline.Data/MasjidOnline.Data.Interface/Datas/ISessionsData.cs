using MasjidOnline.Data.Interface.Repository.Sessions;

namespace MasjidOnline.Data.Interface.Datas;

public interface ISessionsData : IData
{
    ISessionRepository Session { get; }
    ISessionSettingRepository SessionSetting { get; }
}
