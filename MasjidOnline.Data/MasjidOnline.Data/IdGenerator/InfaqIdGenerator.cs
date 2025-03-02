using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class InfaqIdGenerator : IInfaqIdGenerator
{
    private int _transactionId;
    private int _transactionFileId;

    public async Task InitializeAsync(IInfaqData infaqData)
    {
        _transactionId = await infaqData.Infaq.GetMaxIdAsync();
        _transactionFileId = await infaqData.InfaqFile.GetMaxIdAsync();
    }

    public int TransactionId => Interlocked.Increment(ref _transactionId);

    public int TransactionFileId => Interlocked.Increment(ref _transactionFileId);
}
