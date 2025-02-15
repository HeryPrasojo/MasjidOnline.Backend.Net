using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ICoreIdGenerator
{
    Task InitializeAsync(ICoreData coreData);
}
