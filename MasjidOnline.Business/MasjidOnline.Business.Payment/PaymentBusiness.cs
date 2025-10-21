using MasjidOnline.Business.Payment.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Payment;

public class PaymentBusiness(IIdGenerator _idGenerator, IService _service) : IPaymentBusiness
{
    public IPaymentManualBusiness Manual { get; } = new PaymentManualBusiness(_idGenerator, _service);
}
