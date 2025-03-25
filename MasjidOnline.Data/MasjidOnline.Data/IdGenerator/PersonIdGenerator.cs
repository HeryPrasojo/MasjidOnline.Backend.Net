using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class PersonIdGenerator : IPersonIdGenerator
{
    public async Task InitializeAsync(IPersonDatabase personDatabase)
    {
    }
}
