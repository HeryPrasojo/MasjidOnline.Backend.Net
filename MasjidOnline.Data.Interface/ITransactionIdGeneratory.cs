namespace MasjidOnline.Data.Interface;

public interface ITransactionIdGenerator
{
    long TransactionId { get; }
    long TransactionFileId { get; }
}
