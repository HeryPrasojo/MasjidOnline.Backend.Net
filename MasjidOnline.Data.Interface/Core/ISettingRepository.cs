using System.Threading.Tasks;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Data.Interface.Core;

public interface ISettingRepository
{
    Task AddAsync(Setting setting);
}
