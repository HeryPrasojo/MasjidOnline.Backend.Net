using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;

namespace MasjidOnline.Data.EntityFramework.SqLite.Definition;

public class SqLiteLogDefinition(LogDataContext _logDataContext) : SqLiteDefinition(_logDataContext), ILogDefinition
{
}
