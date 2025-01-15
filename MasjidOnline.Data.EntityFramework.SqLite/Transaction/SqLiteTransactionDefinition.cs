using MasjidOnline.Data.Interface.Transactions;

namespace MasjidOnline.Data.EntityFramework.SqLite.Transaction;

public class SqLiteTransactionDefinition(TransactionDataContext _transactionDataContext) : SqLiteDefinition(_transactionDataContext), ITransactionDefinition
{
}
