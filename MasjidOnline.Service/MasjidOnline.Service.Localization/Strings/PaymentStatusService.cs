using System.Collections.Generic;
using System.Globalization;
using MasjidOnline.Service.Localization.Interface.Strings;

namespace MasjidOnline.Service.Localization.Strings;

// undone subclass
public class PaymentStatusService : IPaymentStatusService
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

    public string this[string key]
    {
        get
        {
            var getResult = _paymentStatus.TryGetValue(key, out var values);

            if (!getResult || (values == default)) return key;


            getResult = values.TryGetValue(CultureInfo.CurrentUICulture.NativeName, out var value);

            if (!getResult || (value == default))
            {
                getResult = values.TryGetValue("en", out value);

                if (!getResult || (value == default)) return key;
            }

            return value;
        }
    }
}
