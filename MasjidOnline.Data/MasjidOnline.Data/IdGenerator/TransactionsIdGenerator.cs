using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class TransactionsIdGenerator : IInfaqsIdGenerator
{
    private int _transactionId;
    private int _transactionFileId;

    public async Task InitializeAsync(IInfaqsData infaqsData)
    {
        _transactionId = await infaqsData.Transaction.GetMaxIdAsync();
        _transactionFileId = await infaqsData.TransactionFile.GetMaxIdAsync();
    }

    public int TransactionId => Interlocked.Increment(ref _transactionId);

    public int TransactionFileId => Interlocked.Increment(ref _transactionFileId);
}
