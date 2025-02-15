using MasjidOnline.Data.Interface.Repository.Transactions;

namespace MasjidOnline.Data.Interface.Datas;

public interface ITransactionsData : IData
{
    ITransactionRepository Transaction { get; }
    ITransactionSettingRepository TransactionSetting { get; }
    ITransactionFileRepository TransactionFile { get; }
}
