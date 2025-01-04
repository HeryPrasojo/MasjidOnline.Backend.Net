using System.Threading.Tasks;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Data.Interface;

public interface ISettingRepository
{
    Task AddAsync(Setting setting);
}
