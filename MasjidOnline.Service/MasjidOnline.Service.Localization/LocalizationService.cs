using System;
using System.Collections.Generic;
using System.Globalization;
using MasjidOnline.Service.Localization.Interface;

namespace MasjidOnline.Service.Localization;

public class LocalizationService() : ILocalizationService
{
    private static readonly Dictionary<string, Dictionary<CultureInfo, string>> _strings = new()
    {
        {
            "Invalid",
            new()
            {
                {Constant.English.CultureInfo,    "Invalid"},
                {Constant.Indonesian.CultureInfo, "Tidak sah"},
            }
        },
    };

    public string this[DateTime value, CultureInfo cultureInfo, string format] => value.ToString(format, cultureInfo);

    public string this[decimal value, CultureInfo cultureInfo] => value.ToString(cultureInfo);

    public string this[Enum value, CultureInfo cultureInfo] => this[value.ToString(), cultureInfo];

    public string this[int value, CultureInfo cultureInfo] => value.ToString(cultureInfo);

    public string this[string key, CultureInfo cultureInfo]
    {
        get
        {
            var valueDictionary = _strings.GetValueOrDefault(key);

            if (valueDictionary == default) return key;


            var valueString = valueDictionary.GetValueOrDefault(cultureInfo);

            if (valueString != default) return valueString!;


            if (cultureInfo == Constant.English.CultureInfo) return key;

            valueString = valueDictionary.GetValueOrDefault(Constant.English.CultureInfo);

            if (valueString == default) return key;

            return valueString!;
        }
    }
}
