using MasjidOnline.Business.Payment.Interface;
using MasjidOnline.Business.Payment.Interface.Manual;
using MasjidOnline.Business.Payment.Manual;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Payment;

public class PaymentManualBusiness(IService _service) : IPaymentManualBusiness
{
    public IGetRecommendationNoteBusiness GetRecommendationNote { get; } = new GetRecommendationNoteBusiness(_service);
}
