using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Core;

namespace MasjidOnline.Data;

public class CoreEntityIdGenerator() : ICoreEntityIdGenerator
{

    public async Task InitializeAsync(ICoreData coreData)
    {
    }
}
