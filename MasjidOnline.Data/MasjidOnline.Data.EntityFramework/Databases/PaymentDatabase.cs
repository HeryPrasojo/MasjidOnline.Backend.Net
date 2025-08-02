using MasjidOnline.Data.EntityFramework.Repository.Payment;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Payment;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class PaymentDatabase(
    DbContext _dbContext) : Database(_dbContext), IPaymentDatabase
{
    private IPaymentSettingRepository? _databaseSettingRepository;
    private IManualRecommendationIdRepository? _userInternalPermissionLogRepository;

    public IPaymentSettingRepository DatabaseSetting => _databaseSettingRepository ??= new PaymentSettingRepository(_dbContext);
    public IManualRecommendationIdRepository ManualRecommendationId => _userInternalPermissionLogRepository ??= new ManualRecommendationIdRepository(_dbContext);
}