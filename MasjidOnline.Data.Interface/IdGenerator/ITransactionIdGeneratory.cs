namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ITransactionIdGenerator
{
    int TransactionId { get; }
    int TransactionFileId { get; }
}
