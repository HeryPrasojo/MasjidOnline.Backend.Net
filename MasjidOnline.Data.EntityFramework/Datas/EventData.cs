using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Event;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Event;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class EventData(EventDataContext _eventDataContext) : IEventData
{
    private IEventSettingRepository? _eventSettingRepository;

    private IExceptionRepository? _errorExceptionRepository;


    public IEventSettingRepository EventSetting => _eventSettingRepository ??= new EventSettingRepository(_eventDataContext);


    public IExceptionRepository Exception => _errorExceptionRepository ??= new ExceptionRepository(_eventDataContext);


    public async Task SaveAsync()
    {
        await _eventDataContext.SaveChangesAsync();
    }
}
