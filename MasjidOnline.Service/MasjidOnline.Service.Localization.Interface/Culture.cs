using System.Globalization;

namespace MasjidOnline.Service.Localization.Interface;

public class Culture(string name)
{
    public string Name => name;

    public CultureInfo CultureInfo { get; set; } = new(name);
}
