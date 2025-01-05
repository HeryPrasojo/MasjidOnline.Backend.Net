using System.Threading.Tasks;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Data.Interface.Core;

public interface ICoreSettingRepository
{
    Task AddAsync(CoreSetting setting);
}
