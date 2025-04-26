using MasjidOnline.Business.Payment.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Payment;

public class PaymentBusiness(IIdGenerator _idGenerator) : IPaymentBusiness
{
    public IPaymentManualBusiness Manual { get; } = new PaymentManualBusiness(_idGenerator);
}
