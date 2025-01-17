using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;

namespace MasjidOnline.Data.EntityFramework.SqLite.Definition;

public class SqLiteTransactionDefinition(TransactionDataContext _transactionDataContext) : SqLiteDefinition(_transactionDataContext), ITransactionDefinition
{
}
