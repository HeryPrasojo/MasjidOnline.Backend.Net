using MasjidOnline.Business.Payment.Interface.Manual;

namespace MasjidOnline.Business.Payment.Interface;

public interface IPaymentManualBusiness
{
    IGetRecommendationNoteBusiness GetRecommendationNote { get; }
}
