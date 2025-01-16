using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Transactions;
using MasjidOnline.Entity.Transactions;

namespace MasjidOnline.Data.Initializer;

public abstract class TransactionInitializer(ITransactionData _transactionData, ITransactionDefinition _transactionDefinition) : ITransactionInitializer
{
    public async Task InitializeDatabaseAsync()
    {
        var settingTableExists = await _transactionDefinition.CheckTableExistsAsync("TransactionSetting");

        if (!settingTableExists)
        {
            await CreateTableTransactionSettingAsync();


            var transactionSetting = new TransactionSetting
            {
                Key = TransactionSettingKey.DatabaseVersion,
                Value = "1",
            };

            await _transactionData.TransactionSetting.AddAsync(transactionSetting);


            await CreateTableTransactionAsync();

            await CreateTableTransactionFileAsync();
        }

        await _transactionData.SaveAsync();
    }


    protected abstract Task<int> CreateTableTransactionSettingAsync();

    protected abstract Task<int> CreateTableTransactionAsync();

    protected abstract Task<int> CreateTableTransactionFileAsync();
}
