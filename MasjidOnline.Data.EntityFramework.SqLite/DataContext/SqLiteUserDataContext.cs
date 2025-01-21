using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Datas;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.DataContext;

public class SqLiteUserDataContext(DbContextOptions _dbContextOptions, IAuditData _auditData) : UserDataContext(_dbContextOptions, _auditData)
{
}
