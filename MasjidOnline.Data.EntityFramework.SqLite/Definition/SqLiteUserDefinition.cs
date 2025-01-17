using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;

namespace MasjidOnline.Data.EntityFramework.SqLite.Definition;

public class SqLiteUserDefinition(UserDataContext _userDataContext) : SqLiteDefinition(_userDataContext), IUserDefinition
{
}
