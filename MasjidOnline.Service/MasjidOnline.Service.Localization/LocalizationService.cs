using System;
using System.Collections.Generic;
using System.Globalization;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Localization.Interface;
using MasjidOnline.Service.Localization.Interface.Model;

namespace MasjidOnline.Service.Localization;

public class LocalizationService() : ILocalizationService
{
    private static readonly Dictionary<string, Dictionary<CultureInfo, string>> _strings = new()
    {
        {
            "Invalid",
            new Dictionary<CultureInfo, string>
            {
                {Constant.CultureInfoEnglish, "Invalid"},
                {Constant.CultureInfoIndonesian, "Tidak sah"},
            }
        },
        {
            "New",
            new Dictionary<CultureInfo, string>
            {
                {Constant.CultureInfoEnglish, ""},
                {Constant.CultureInfoIndonesian, ""},
            }
        },
        {
            "",
            new Dictionary<CultureInfo, string>
            {
                {Constant.CultureInfoEnglish, ""},
                {Constant.CultureInfoIndonesian, ""},
            }
        },
    };

    public string this[DateTime value, CultureInfo cultureInfo] => value.ToString("yyyy MMM dd, HH:mm", cultureInfo);

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

            if (!valueString.IsNullOrEmptyOrWhiteSpace()) return valueString!;


            if (cultureInfo == Constant.CultureInfoEnglish) return key;

            valueString = valueDictionary.GetValueOrDefault(Constant.CultureInfoEnglish);

            if (valueString.IsNullOrEmptyOrWhiteSpace()) return key;

            return valueString!;
            //return _strings[key][cultureInfo];
        }
    }
}
