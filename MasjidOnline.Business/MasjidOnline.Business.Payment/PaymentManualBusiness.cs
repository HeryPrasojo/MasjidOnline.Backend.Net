using MasjidOnline.Business.Payment.Interface;
using MasjidOnline.Business.Payment.Interface.Manual;
using MasjidOnline.Business.Payment.Manual;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Payment;

public class PaymentManualBusiness(IIdGenerator _idGenerator) : IPaymentManualBusiness
{
    public IGetRecommendationNoteBusiness GetRecommendationNote { get; } = new GetRecommendationNoteBusiness(_idGenerator);
}
