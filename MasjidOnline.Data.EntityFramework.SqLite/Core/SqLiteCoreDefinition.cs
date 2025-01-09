using MasjidOnline.Data.Interface.Core;

namespace MasjidOnline.Data.EntityFramework.SqLite.Core;

public class SqLiteCoreDefinition(CoreDataContext _coreDataContext) : SqLiteDefinition(_coreDataContext), ICoreDefinition
{
}
