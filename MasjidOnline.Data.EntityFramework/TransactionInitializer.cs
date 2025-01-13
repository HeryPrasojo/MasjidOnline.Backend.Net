using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Transaction;
using MasjidOnline.Entity.Transaction;

namespace MasjidOnline.Data.EntityFramework;

public abstract class TransactionInitializer : TransactionData, ITransactionInitializer
{
    public TransactionInitializer(
        TransactionDataContext transactionDataContext,
        ITransactionDefinition transactionDefinition) : base(transactionDataContext)
    {
        InitializeDatabaseAsync(transactionDefinition).Wait();
    }

    private async Task InitializeDatabaseAsync(ITransactionDefinition transactionDefinition)
    {
        var settingTableExists = await transactionDefinition.CheckTableExistsAsync("TransactionSetting");

        if (!settingTableExists)
        {
            await CreateTableTransactionSettingAsync();

            var transactionSetting = new TransactionSetting
            {
                Key = TransactionSettingKey.DatabaseVersion,
                Value = "1",
            };

            await TransactionSetting.AddAsync(transactionSetting);


        }

        await SaveAsync();
    }


    protected abstract Task<int> CreateTableTransactionSettingAsync();
}
