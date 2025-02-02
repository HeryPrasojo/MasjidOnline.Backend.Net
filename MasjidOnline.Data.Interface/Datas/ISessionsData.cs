using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Sessions;

namespace MasjidOnline.Data.Interface.Datas;

public interface ISessionsData
{
    ISessionRepository Session { get; }
    ISessionSettingRepository SessionSetting { get; }

    Task SaveAsync();
}
