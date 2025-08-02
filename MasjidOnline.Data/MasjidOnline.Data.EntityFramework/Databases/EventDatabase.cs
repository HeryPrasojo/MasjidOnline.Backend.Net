using MasjidOnline.Data.EntityFramework.Repository.Event;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Event;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class EventDatabase(DbContext _dbContext) : Database(_dbContext), IEventDatabase
{
    private IEventSettingRepository? _eventSettingRepository;

    private IExceptionRepository? _exceptionRepository;


    public IEventSettingRepository EventSetting => _eventSettingRepository ??= new EventSettingRepository(_dbContext);


    public IExceptionRepository Exception => _exceptionRepository ??= new ExceptionRepository(_dbContext);
}
