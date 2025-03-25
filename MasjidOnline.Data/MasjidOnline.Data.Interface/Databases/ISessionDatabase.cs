using MasjidOnline.Data.Interface.Repository.Session;

namespace MasjidOnline.Data.Interface.Databases;

public interface ISessionDatabase : IDatabase
{
    ISessionRepository Session { get; }
    ISessionSettingRepository SessionSetting { get; }
}
