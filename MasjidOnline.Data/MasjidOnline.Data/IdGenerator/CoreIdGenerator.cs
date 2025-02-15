using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class CoreIdGenerator : ICoreIdGenerator
{
    public async Task InitializeAsync(ICoreData coreData)
    {
    }
}
