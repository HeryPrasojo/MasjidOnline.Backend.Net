using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class InfaqIdGenerator : IInfaqIdGenerator
{
    private int _expireId;
    private int _infaqId;
    private int _infaqFileId;
    private int _successId;
    private int _voidId;

    public async Task InitializeAsync(IData data)
    {
        _expireId = await data.Infaq.Expire.GetMaxIdAsync();
        _infaqId = await data.Infaq.Infaq.GetMaxIdAsync();
        _infaqFileId = await data.Infaq.InfaqFile.GetMaxIdAsync();
        _successId = await data.Infaq.Success.GetMaxIdAsync();
        _voidId = await data.Infaq.Void.GetMaxIdAsync();
    }

    public int ExpireId => Interlocked.Increment(ref _expireId);

    public int InfaqId => Interlocked.Increment(ref _infaqId);

    public int InfaqFileId => Interlocked.Increment(ref _infaqFileId);

    public int SuccessId => Interlocked.Increment(ref _successId);

    public int VoidId => Interlocked.Increment(ref _voidId);
}
