using MasjidOnline.Data.Interface.Repository.Session;

namespace MasjidOnline.Data.Interface.Datas;

public interface ISessionDatabase : IData
{
    ISessionRepository Session { get; }
    ISessionSettingRepository SessionSetting { get; }
}
