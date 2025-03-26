using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class PersonIdGenerator : IPersonIdGenerator
{
    public async Task InitializeAsync(IData data)
    {
    }
}
