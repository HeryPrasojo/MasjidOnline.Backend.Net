using MasjidOnline.Data.Interface.Repository.Event;

namespace MasjidOnline.Data.Interface.Databases;

public interface IEventDatabase : IDatabase
{
    IExceptionRepository Exception { get; }
    IEventSettingRepository EventSetting { get; }
}
