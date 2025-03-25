using MasjidOnline.Data.Interface.Repository.Session;

namespace MasjidOnline.Data.Interface.Databases;

public interface ISessionDatabase : IData
{
    ISessionRepository Session { get; }
    ISessionSettingRepository SessionSetting { get; }
}
