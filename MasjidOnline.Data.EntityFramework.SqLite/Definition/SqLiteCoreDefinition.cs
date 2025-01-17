using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;

namespace MasjidOnline.Data.EntityFramework.SqLite.Definition;

public class SqLiteCoreDefinition(CoreDataContext _coreDataContext) : SqLiteDefinition(_coreDataContext), ICoreDefinition
{
}
