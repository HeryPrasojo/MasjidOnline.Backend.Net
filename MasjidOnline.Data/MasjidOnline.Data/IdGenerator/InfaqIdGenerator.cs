using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class InfaqIdGenerator : IInfaqIdGenerator
{
    private int _expireId;
    private int _infaqId;
    private int _infaqFileId;
    private int _successId;
    private int _voidId;

    public async Task InitializeAsync(IInfaqDatabase infaqDatabase)
    {
        _expireId = await infaqDatabase.Expire.GetMaxIdAsync();
        _infaqId = await infaqDatabase.Infaq.GetMaxIdAsync();
        _infaqFileId = await infaqDatabase.InfaqFile.GetMaxIdAsync();
        _successId = await infaqDatabase.Success.GetMaxIdAsync();
        _voidId = await infaqDatabase.Void.GetMaxIdAsync();
    }

    public int ExpireId => Interlocked.Increment(ref _expireId);

    public int InfaqId => Interlocked.Increment(ref _infaqId);

    public int InfaqFileId => Interlocked.Increment(ref _infaqFileId);

    public int SuccessId => Interlocked.Increment(ref _successId);

    public int VoidId => Interlocked.Increment(ref _voidId);
}
