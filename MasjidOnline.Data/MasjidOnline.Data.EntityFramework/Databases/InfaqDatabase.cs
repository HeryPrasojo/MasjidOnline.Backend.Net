using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Infaq;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Infaq;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class InfaqDatabase(InfaqDataContext _infaqDataContext) : Database(_infaqDataContext), IInfaqDatabase
{
    private IExpireRepository? _expireRepository;
    private IInfaqRepository? _infaqRepository;
    private IInfaqFileRepository? _infaqFileRepository;
    private IInfaqManualRepository? _infaqManualRepository;
    private IInfaqSettingRepository? _infaqSettingRepository;
    private IPaymentRepository? _paymentRepository;
    private ISuccessRepository? _successRepository;
    private IVoidRepository? _voidRepository;

    public IExpireRepository Expire => _expireRepository ??= new ExpireRepository(_infaqDataContext);

    public IInfaqRepository Infaq => _infaqRepository ??= new InfaqRepository(_infaqDataContext);

    public IInfaqFileRepository InfaqFile => _infaqFileRepository ??= new InfaqFileRepository(_infaqDataContext);

    public IInfaqManualRepository InfaqManual => _infaqManualRepository ??= new InfaqManualRepository(_infaqDataContext);

    public IInfaqSettingRepository InfaqSetting => _infaqSettingRepository ??= new InfaqSettingRepository(_infaqDataContext);

    public IPaymentRepository Payment => _paymentRepository ??= new PaymentRepository(_infaqDataContext);

    public ISuccessRepository Success => _successRepository ??= new SuccessRepository(_infaqDataContext);

    public IVoidRepository Void => _voidRepository ??= new VoidRepository(_infaqDataContext);
}
