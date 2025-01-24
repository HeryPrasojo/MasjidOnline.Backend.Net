using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Transactions;

namespace MasjidOnline.Data.Initializer;

public abstract class TransactionInitializer(ITransactionDefinition _transactionDefinition) : ITransactionInitializer
{
    public async Task InitializeDatabaseAsync(ITransactionData transactionData)
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

            await transactionData.TransactionSetting.AddAsync(transactionSetting);


            await CreateTableTransactionAsync();

            await CreateTableTransactionFileAsync();

            await transactionData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableTransactionSettingAsync();

    protected abstract Task<int> CreateTableTransactionAsync();

    protected abstract Task<int> CreateTableTransactionFileAsync();
}
