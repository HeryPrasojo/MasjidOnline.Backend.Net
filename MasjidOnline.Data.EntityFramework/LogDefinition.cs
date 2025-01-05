using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data.EntityFramework;

public class LogDefinition(DataContext _dataContext) : LogData(_dataContext), ILogDefinition
{
}
