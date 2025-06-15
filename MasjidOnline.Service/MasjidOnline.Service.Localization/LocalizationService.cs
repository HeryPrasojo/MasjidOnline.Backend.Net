using System;
using MasjidOnline.Service.Localization.Interface;

namespace MasjidOnline.Service.Localization;

public class LocalizationService(ILocalizationStringService _strings) : ILocalizationService
{
    public ILocalizationStringService Strings { get; } = _strings;

    public string FormatDateTime(DateTime value)
    {
        return value.ToString("yyyy MMM dd, HH:mm");
    }

    public string FormatDecimal(decimal value)
    {
        return value.ToString();
    }

    public string FormatInt(int value)
    {
        return value.ToString();
    }
}
