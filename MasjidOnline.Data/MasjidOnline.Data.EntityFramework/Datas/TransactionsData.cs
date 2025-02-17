using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Transactions;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Infaqs;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class TransactionsData(TransactionsDataContext _transactionDataContext) : DataWithoutAudit(_transactionDataContext), IInfaqsData
{
    private IInfaqSettingRepository? _infaqSettingRepository;

    private IInfaqRepository? _infaqRepository;
    private IInfaqFileRepository? _infaqFileRepository;


    public IInfaqSettingRepository InfaqSetting => _infaqSettingRepository ??= new TransactionSettingRepository(_transactionDataContext);


    public IInfaqRepository Infaq => _infaqRepository ??= new TransactionRepository(_transactionDataContext);

    public IInfaqFileRepository InfaqFile => _infaqFileRepository ??= new TransactionFileRepository(_transactionDataContext);
}
