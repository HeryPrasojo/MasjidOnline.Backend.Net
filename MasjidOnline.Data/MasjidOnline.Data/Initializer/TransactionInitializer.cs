using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Initializer;

public abstract class TransactionInitializer(IInfaqsDefinition _infaqsDefinition) : ITransactionsInitializer
{
    public async Task InitializeDatabaseAsync(IInfaqsData infaqsData)
    {
        var settingTableExists = await _infaqsDefinition.CheckTableExistsAsync(nameof(InfaqSetting));

        if (!settingTableExists)
        {
            await CreateTableTransactionSettingAsync();
            await CreateTableTransactionAsync();
            await CreateTableTransactionFileAsync();


            var transactionSetting = new InfaqSetting
            {
                Id = (int)InfaqSettingId.DatabaseVersion,
                Description = nameof(InfaqSettingId.DatabaseVersion),
                Value = "1",
            };

            await infaqsData.TransactionSetting.AddAsync(transactionSetting);

            await infaqsData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableTransactionSettingAsync();

    protected abstract Task<int> CreateTableTransactionAsync();

    protected abstract Task<int> CreateTableTransactionFileAsync();
}
