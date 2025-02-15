using MasjidOnline.Data.Interface.Repository.Event;

namespace MasjidOnline.Data.Interface.Datas;

public interface IEventData : IDataWithoutAudit
{
    IExceptionRepository Exception { get; }
    IEventSettingRepository EventSetting { get; }
}
