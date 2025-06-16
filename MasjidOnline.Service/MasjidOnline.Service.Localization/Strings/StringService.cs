using System.Collections.Generic;
using System.Globalization;

namespace MasjidOnline.Service.Localization.Strings;

public abstract class StringService
{
    protected abstract Dictionary<string, Dictionary<string, string>> Dictionaries { get; }

    public string this[string key]
    {
        get
        {
            var getResult = Dictionaries.TryGetValue(key, out var values);

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
