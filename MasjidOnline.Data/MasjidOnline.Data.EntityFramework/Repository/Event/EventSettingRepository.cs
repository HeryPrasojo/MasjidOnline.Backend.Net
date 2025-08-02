using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Event;
using MasjidOnline.Entity.Event;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Event;

public class EventSettingRepository(DbContext _dbContext) : IEventSettingRepository
{
    private readonly DbSet<EventSetting> _dbSet = _dbContext.Set<EventSetting>();

    public async Task AddAndSaveAsync(EventSetting eventSetting)
    {
        await _dbSet.AddAsync(eventSetting);

        await _dbContext.SaveChangesAsync();
    }
}
