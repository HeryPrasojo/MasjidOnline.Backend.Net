using System;
using System.Globalization;

namespace MasjidOnline.Service.Localization.Interface;

public interface ILocalizationService
{
    string this[DateTime value, CultureInfo cultureInfo] { get; }
    string this[decimal value, CultureInfo cultureInfo] { get; }
    string this[int value, CultureInfo cultureInfo] { get; }
    string this[string key, CultureInfo cultureInfo] { get; }
    string this[Enum value, CultureInfo cultureInfo] { get; }
}
