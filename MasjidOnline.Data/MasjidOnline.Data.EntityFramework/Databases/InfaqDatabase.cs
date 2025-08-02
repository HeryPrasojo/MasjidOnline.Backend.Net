using MasjidOnline.Data.EntityFramework.Repository.Infaq;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class InfaqDatabase(DbContext _dbContext) : Database(_dbContext), IInfaqDatabase
{
    private IExpireRepository? _expireRepository;
    private IInfaqRepository? _infaqRepository;
    private IInfaqFileRepository? _infaqFileRepository;
    private IInfaqManualRepository? _infaqManualRepository;
    private IInfaqSettingRepository? _infaqSettingRepository;
    private IPaymentRepository? _paymentRepository;
    private ISuccessRepository? _successRepository;
    private IVoidRepository? _voidRepository;

    public IExpireRepository Expire => _expireRepository ??= new ExpireRepository(_dbContext);

    public IInfaqRepository Infaq => _infaqRepository ??= new InfaqRepository(_dbContext);

    public IInfaqFileRepository InfaqFile => _infaqFileRepository ??= new InfaqFileRepository(_dbContext);

    public IInfaqManualRepository InfaqManual => _infaqManualRepository ??= new InfaqManualRepository(_dbContext);

    public IInfaqSettingRepository InfaqSetting => _infaqSettingRepository ??= new InfaqSettingRepository(_dbContext);

    public IPaymentRepository Payment => _paymentRepository ??= new PaymentRepository(_dbContext);

    public ISuccessRepository Success => _successRepository ??= new SuccessRepository(_dbContext);

    public IVoidRepository Void => _voidRepository ??= new VoidRepository(_dbContext);
}
