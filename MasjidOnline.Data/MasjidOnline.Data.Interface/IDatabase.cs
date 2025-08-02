using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDatabase
{
    object? TransactionObject { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RolbackTransactionAsync();
    Task SaveAsync();
    Task UseTransactionAsync(object? transactionObject);
}
