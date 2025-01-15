using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Transactions;
using MasjidOnline.Entity.Transactions;

namespace MasjidOnline.Data.Initializer;

public abstract class TransactionInitializer : ITransactionInitializer
{
    private readonly ITransactionData _transactionData;
    private readonly ITransactionDefinition _transactionDefinition;

    public TransactionInitializer(
        ITransactionData transactionData,
        ITransactionDefinition transactionDefinition)
    {
        _transactionData = transactionData;
        _transactionDefinition = transactionDefinition;
    }

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

    protected abstract Task CreateTableTransactionAsync();

    protected abstract Task CreateTableTransactionFileAsync();
}
