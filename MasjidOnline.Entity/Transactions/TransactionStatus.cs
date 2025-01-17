namespace MasjidOnline.Entity.Transactions;

public enum TransactionStatus
{
    None = 0,
    Success = 11,
    Fail = 21,
    Verifying = 31,
    Expired = 41,
    Pending = 51,
}
