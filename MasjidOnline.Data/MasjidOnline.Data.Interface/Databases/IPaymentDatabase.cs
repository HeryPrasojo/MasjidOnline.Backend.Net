using MasjidOnline.Data.Interface.Repository.Payment;

namespace MasjidOnline.Data.Interface.Databases;

public interface IPaymentDatabase : IDatabase
{
    IPaymentSettingRepository DatabaseSetting { get; }

    IManualRecommendationIdRepository ManualRecommendationId { get; }
}
