using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class TransactionIdGenerator : ITransactionIdGenerator
{
    private int _transactionId;
    private int _transactionFileId;

    public async Task InitializeAsync(ITransactionData transactionData)
    {
        _transactionId = await transactionData.Transaction.GetMaxIdAsync();
        _transactionFileId = await transactionData.TransactionFile.GetMaxIdAsync();
    }

    public int TransactionId => Interlocked.Increment(ref _transactionId);

    public int TransactionFileId => Interlocked.Increment(ref _transactionFileId);
}
