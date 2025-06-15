using MasjidOnline.Service.Localization.Interface;
using MasjidOnline.Service.Localization.Interface.Strings;

namespace MasjidOnline.Service.Localization;

public class LocalizationStringService(IPaymentStatusService _paymentStatusService) : ILocalizationStringService
{
    public IPaymentStatusService PaymentStatus { get; } = _paymentStatusService;

    //public Dictionary<string, string> PaymentStatus
    //{
    //    get
    //    {
    //        return new Dictionary<string, string>() { { "", "" }, };
    //    }
    //}
}
