using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Infaqs;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Infaqs;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class InfaqsData(InfaqsDataContext _infaqsDataContext) : DataWithoutAudit(_infaqsDataContext), IInfaqsData
{
    private IExpiredRepository? _expiredRepository;
    private IInfaqRepository? _infaqRepository;
    private IInfaqFileRepository? _infaqFileRepository;
    private IInfaqManualRepository? _infaqManualRepository;
    private IInfaqSettingRepository? _infaqSettingRepository;

    public IExpiredRepository Expired => _expiredRepository ??= new ExpiredRepository(_infaqsDataContext);

    public IInfaqRepository Infaq => _infaqRepository ??= new InfaqRepository(_infaqsDataContext);

    public IInfaqFileRepository InfaqFile => _infaqFileRepository ??= new InfaqFileRepository(_infaqsDataContext);

    public IInfaqManualRepository InfaqManual => _infaqManualRepository ??= new InfaqManualRepository(_infaqsDataContext);

    public IInfaqSettingRepository InfaqSetting => _infaqSettingRepository ??= new InfaqSettingRepository(_infaqsDataContext);
}
