using System.Collections.Generic;
using System.Globalization;

namespace MasjidOnline.Service.Localization.Interface.Model;

public static class Constant
{
    private const string CultureNameEnglish = "en";
    private const string CultureNameIndonesian = "id";

    public static readonly CultureInfo CultureInfoEnglish = new(CultureNameEnglish);
    public static readonly CultureInfo CultureInfoIndonesian = new(CultureNameIndonesian);

    public static readonly Dictionary<string, CultureInfo> CultureInfos = new()
    {
        { CultureNameEnglish, CultureInfoEnglish },
        { CultureNameIndonesian, CultureInfoIndonesian },
    };
}
