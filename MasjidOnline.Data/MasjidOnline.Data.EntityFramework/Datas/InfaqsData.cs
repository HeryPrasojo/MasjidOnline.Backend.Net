using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Infaqs;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Infaqs;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class InfaqsData(TransactionsDataContext _transactionDataContext) : DataWithoutAudit(_transactionDataContext), IInfaqsData
{
    private IInfaqSettingRepository? _infaqSettingRepository;

    private IInfaqRepository? _infaqRepository;
    private IInfaqFileRepository? _infaqFileRepository;


    public IInfaqSettingRepository InfaqSetting => _infaqSettingRepository ??= new InfaqSettingRepository(_transactionDataContext);


    public IInfaqRepository Infaq => _infaqRepository ??= new InfaqRepository(_transactionDataContext);

    public IInfaqFileRepository InfaqFile => _infaqFileRepository ??= new InfaqFileRepository(_transactionDataContext);
}
