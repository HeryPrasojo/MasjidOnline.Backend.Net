using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Transaction;

public class SqLiteTransactionDataContext(DbContextOptions _dbContextOptions) : TransactionDataContext(_dbContextOptions)
{
}
