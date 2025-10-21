using MasjidOnline.Business.Payment.Interface;
using MasjidOnline.Business.Payment.Interface.Manual;
using MasjidOnline.Business.Payment.Manual;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Payment;

public class PaymentManualBusiness(IIdGenerator _idGenerator, IService _service) : IPaymentManualBusiness
{
    public IGetRecommendationNoteBusiness GetRecommendationNote { get; } = new GetRecommendationNoteBusiness(_idGenerator, _service);
}
