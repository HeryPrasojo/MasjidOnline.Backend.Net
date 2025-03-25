using MasjidOnline.Data.Interface.Repository.Event;

namespace MasjidOnline.Data.Interface.Databases;

public interface IEventDatabase : IData
{
    IExceptionRepository Exception { get; }
    IEventSettingRepository EventSetting { get; }
}
