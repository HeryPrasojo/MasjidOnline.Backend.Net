using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class InfaqsIdGenerator : IInfaqsIdGenerator
{
    private int _transactionId;
    private int _transactionFileId;

    public async Task InitializeAsync(IInfaqsData infaqsData)
    {
        _transactionId = await infaqsData.Infaq.GetMaxIdAsync();
        _transactionFileId = await infaqsData.InfaqFile.GetMaxIdAsync();
    }

    public int TransactionId => Interlocked.Increment(ref _transactionId);

    public int TransactionFileId => Interlocked.Increment(ref _transactionFileId);
}
