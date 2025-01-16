using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.Transactions;
using MasjidOnline.Data.Interface.Transactions;

namespace MasjidOnline.Data.EntityFramework;

public class TransactionData(TransactionDataContext _transactionDataContext) : ITransactionData
{
    private ITransactionRepository? _transactionRepository;
    private ITransactionFileRepository? _transactionFileRepository;
    private ITransactionSettingRepository? _transactionSettingRepository;

    public async Task<int> SaveAsync()
    {
        return await _transactionDataContext.SaveChangesAsync();
    }


    public ITransactionRepository Transaction => _transactionRepository ??= new TransactionRepository(_transactionDataContext);

    public ITransactionFileRepository TransactionFile => _transactionFileRepository ??= new TransactionFileRepository(_transactionDataContext);

    public ITransactionSettingRepository TransactionSetting => _transactionSettingRepository ??= new TransactionSettingRepository(_transactionDataContext);
}
