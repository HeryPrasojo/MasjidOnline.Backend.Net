namespace MasjidOnline.Data.Interface.Transactions;

public interface ITransactionData : IData
{
    ITransactionRepository Transaction { get; }
    ITransactionSettingRepository TransactionSetting { get; }
}
