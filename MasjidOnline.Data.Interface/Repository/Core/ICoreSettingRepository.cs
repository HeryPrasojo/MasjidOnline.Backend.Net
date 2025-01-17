using System.Threading.Tasks;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Data.Interface.Repository.Core;

public interface ICoreSettingRepository
{
    Task AddAsync(CoreSetting setting);
}
