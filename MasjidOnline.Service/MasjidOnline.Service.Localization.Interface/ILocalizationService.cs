using System;

namespace MasjidOnline.Service.Localization.Interface;

public interface ILocalizationService
{
    ILocalizationStringService Strings { get; }

    string FormatDateTime(DateTime value);
    string FormatDecimal(decimal value);
    string FormatInt(int value);
}
