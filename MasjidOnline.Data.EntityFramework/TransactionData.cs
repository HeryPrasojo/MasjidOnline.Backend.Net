using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.Transactions;
using MasjidOnline.Data.Interface.Transaction;

namespace MasjidOnline.Data.EntityFramework;

public class TransactionData : ITransactionData
{
    protected readonly TransactionDataContext _transactionDataContext;

    private ITransactionRepository? _transactionRepository;
    private ITransactionSettingRepository? _transactionSettingRepository;

    public TransactionData(TransactionDataContext transactionDataContext)
    {
        _transactionDataContext = transactionDataContext;
    }

    public async Task<int> SaveAsync()
    {
        return await _transactionDataContext.SaveChangesAsync();
    }


    public ITransactionRepository Transaction => _transactionRepository ??= new TransactionRepository(_transactionDataContext);

    public ITransactionSettingRepository TransactionSetting => _transactionSettingRepository ??= new TransactionSettingRepository(_transactionDataContext);
}
