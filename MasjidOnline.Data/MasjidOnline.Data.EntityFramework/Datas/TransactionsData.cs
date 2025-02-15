using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Transactions;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Transactions;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class TransactionsData(TransactionsDataContext _transactionDataContext) : DataWithoutAudit(_transactionDataContext), ITransactionsData
{
    private ITransactionSettingRepository? _transactionSettingRepository;

    private ITransactionRepository? _transactionRepository;
    private ITransactionFileRepository? _transactionFileRepository;


    public ITransactionSettingRepository TransactionSetting => _transactionSettingRepository ??= new TransactionSettingRepository(_transactionDataContext);


    public ITransactionRepository Transaction => _transactionRepository ??= new TransactionRepository(_transactionDataContext);

    public ITransactionFileRepository TransactionFile => _transactionFileRepository ??= new TransactionFileRepository(_transactionDataContext);
}
