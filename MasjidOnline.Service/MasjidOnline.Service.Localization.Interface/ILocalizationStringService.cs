using MasjidOnline.Service.Localization.Interface.Strings;

namespace MasjidOnline.Service.Localization.Interface;

public interface ILocalizationStringService
{
    IPaymentStatusService PaymentStatus { get; }
}
