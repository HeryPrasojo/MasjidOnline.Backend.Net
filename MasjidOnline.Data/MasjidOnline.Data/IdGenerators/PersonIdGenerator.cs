using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class PersonIdGenerator : IPersonIdGenerator
{
    private int _personId;

    public async Task InitializeAsync(IData data)
    {
        _personId = await data.Person.Person.GetMaxIdAsync();
    }


    public int PersonId => Interlocked.Increment(ref _personId);
}
