using System.Collections.Generic;
using MasjidOnline.Service.Localization.Interface.Strings;

namespace MasjidOnline.Service.Localization.Strings;

public class PaymentStatusService : StringService, IPaymentStatusService
{
    private readonly Dictionary<string, Dictionary<string, string>> _paymentStatus = new()
    {
        {
            "Cancel",
            new Dictionary<string, string>
            {
                {"en", "Canceled"},
            }
        },
    };

    protected override Dictionary<string, Dictionary<string, string>> Dictionaries => _paymentStatus;
}
