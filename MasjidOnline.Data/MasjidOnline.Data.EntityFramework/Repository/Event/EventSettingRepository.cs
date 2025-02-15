using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Event;
using MasjidOnline.Entity.Event;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Event;

public class EventSettingRepository(EventDataContext _eventDataContext) : IEventSettingRepository
{
    private readonly DbSet<EventSetting> _dbSet = _eventDataContext.Set<EventSetting>();

    public async Task AddAsync(EventSetting eventSetting)
    {
        await _dbSet.AddAsync(eventSetting);
    }
}
