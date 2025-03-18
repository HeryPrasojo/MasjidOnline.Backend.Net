using MasjidOnline.Data.Interface.Repository.Session;

namespace MasjidOnline.Data.Interface.Datas;

public interface ISessionData : IData
{
    ISessionRepository Session { get; }
    ISessionSettingRepository SessionSetting { get; }
}
