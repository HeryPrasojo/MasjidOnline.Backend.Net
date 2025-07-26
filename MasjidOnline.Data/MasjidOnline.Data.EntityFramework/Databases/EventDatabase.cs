using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Event;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Event;

namespace MasjidOnline.Data.EntityFramework.Databases;

// todo low change *DataContext to DbContext
public class EventDatabase(EventDataContext _eventDataContext) : Database(_eventDataContext), IEventDatabase
{
    private IEventSettingRepository? _eventSettingRepository;

    private IExceptionRepository? _exceptionRepository;


    public IEventSettingRepository EventSetting => _eventSettingRepository ??= new EventSettingRepository(_eventDataContext);


    public IExceptionRepository Exception => _exceptionRepository ??= new ExceptionRepository(_eventDataContext);
}
