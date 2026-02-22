using MasjidOnline.Data.EntityFramework.Repository.Payment;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Payment;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class PaymentDatabase(
    DbContext _dbContext) : Database(_dbContext), IPaymentDatabase
{
    private IManualRecommendationIdRepository? _userInternalPermissionLogRepository;
    private IPaymentRepository? _paymentRepository;
    private IPaymentFileRepository? _paymentFileRepository;
    private IPaymentSettingRepository? _paymentSettingRepository;

    public IManualRecommendationIdRepository ManualRecommendationId => _userInternalPermissionLogRepository ??= new ManualRecommendationIdRepository(_dbContext);
    public IPaymentRepository Payment => _paymentRepository ??= new PaymentRepository(_dbContext);
    public IPaymentFileRepository PaymentFile => _paymentFileRepository ??= new PaymentFileRepository(_dbContext);
    public IPaymentSettingRepository PaymentSetting => _paymentSettingRepository ??= new PaymentSettingRepository(_dbContext);
}