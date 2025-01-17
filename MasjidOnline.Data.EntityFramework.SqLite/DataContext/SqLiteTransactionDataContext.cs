using MasjidOnline.Data.EntityFramework.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.DataContext;

public class SqLiteTransactionDataContext(DbContextOptions _dbContextOptions) : TransactionDataContext(_dbContextOptions)
{
}
