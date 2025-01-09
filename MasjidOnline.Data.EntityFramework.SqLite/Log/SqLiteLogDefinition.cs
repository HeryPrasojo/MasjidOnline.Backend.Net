using MasjidOnline.Data.Interface.Log;

namespace MasjidOnline.Data.EntityFramework.SqLite.Log;

public class SqLiteLogDefinition(LogDataContext _logDataContext) : SqLiteDefinition(_logDataContext), ILogDefinition
{
}
