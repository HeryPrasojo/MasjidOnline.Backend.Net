using MasjidOnline.Business.Payment.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Payment;

public class PaymentBusiness(IService _service) : IPaymentBusiness
{
    public IPaymentManualBusiness Manual { get; } = new PaymentManualBusiness(_service);
}
