using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Payment;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Payment;

namespace MasjidOnline.Data.EntityFramework.Databases;

// todo low change *DataContext to DbContext
public class PaymentDatabase(
    PaymentDataContext _databaseDataContext) : Database(_databaseDataContext), IPaymentDatabase
{
    private IPaymentSettingRepository? _databaseSettingRepository;
    private IManualRecommendationIdRepository? _userInternalPermissionLogRepository;

    public IPaymentSettingRepository DatabaseSetting => _databaseSettingRepository ??= new PaymentSettingRepository(_databaseDataContext);
    public IManualRecommendationIdRepository ManualRecommendationId => _userInternalPermissionLogRepository ??= new ManualRecommendationIdRepository(_databaseDataContext);
}