using System.Globalization;

namespace MasjidOnline.Service.Serializer.Interface;

public interface ISerializerService
{
    string Serialize(object obj, CultureInfo cultureInfo);
}
