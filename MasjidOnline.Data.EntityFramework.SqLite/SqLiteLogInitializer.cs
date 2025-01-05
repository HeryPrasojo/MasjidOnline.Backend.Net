using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public class SqLiteLogInitializer(
    LogDataContext _dataContext,
    ILogDefinition _logDefinition) : LogInitializer(_dataContext, _logDefinition)
{
}
