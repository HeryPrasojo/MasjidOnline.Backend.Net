using MasjidOnline.Data.Interface.Repository.Payment;

namespace MasjidOnline.Data.Interface.Databases;

public interface IPaymentDatabase : IDatabase
{
    IPaymentSettingRepository PaymentSetting { get; }

    IManualRecommendationIdRepository ManualRecommendationId { get; }
    IPaymentRepository Payment { get; }
    IPaymentFileRepository PaymentFile { get; }
}
