using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Event;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Event;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class EventDatabase(EventDataContext _eventDataContext) : Data(_eventDataContext), IEventDatabase
{
    private IEventSettingRepository? _eventSettingRepository;

    private IExceptionRepository? _errorExceptionRepository;


    public IEventSettingRepository EventSetting => _eventSettingRepository ??= new EventSettingRepository(_eventDataContext);


    public IExceptionRepository Exception => _errorExceptionRepository ??= new ExceptionRepository(_eventDataContext);
}
