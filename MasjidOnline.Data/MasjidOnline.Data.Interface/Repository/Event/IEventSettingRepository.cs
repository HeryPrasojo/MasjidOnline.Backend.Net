using System.Threading.Tasks;
using MasjidOnline.Entity.Event;

namespace MasjidOnline.Data.Interface.Repository.Event;

public interface IEventSettingRepository
{
    Task AddAndSaveAsync(EventSetting eventSetting);
}
