using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ITransactionIdGenerator
{
    int TransactionId { get; }
    int TransactionFileId { get; }

    Task InitializeAsync(ITransactionData transactionData);
}
