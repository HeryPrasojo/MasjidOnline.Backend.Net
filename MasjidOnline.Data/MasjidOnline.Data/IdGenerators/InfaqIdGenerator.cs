using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class InfaqIdGenerator : IInfaqIdGenerator
{
    private int _infaqId;

    public async Task InitializeAsync(IData data)
    {
        _infaqId = await data.Infaq.Infaq.GetMaxIdAsync();
    }

    public int InfaqId => Interlocked.Increment(ref _infaqId);
}
