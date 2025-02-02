﻿using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Transactions;

namespace MasjidOnline.Data.Initializer;

public abstract class TransactionInitializer(ITransactionsDefinition _transactionDefinition) : ITransactionsInitializer
{
    public async Task InitializeDatabaseAsync(ITransactionsData transactionData)
    {
        var settingTableExists = await _transactionDefinition.CheckTableExistsAsync(nameof(TransactionSetting));

        if (!settingTableExists)
        {
            await CreateTableTransactionSettingAsync();
            await CreateTableTransactionAsync();
            await CreateTableTransactionFileAsync();


            var transactionSetting = new TransactionSetting
            {
                Id = (int)TransactionSettingId.DatabaseVersion,
                Description = nameof(TransactionSettingId.DatabaseVersion),
                Value = "1",
            };

            await transactionData.TransactionSetting.AddAsync(transactionSetting);

            await transactionData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableTransactionSettingAsync();

    protected abstract Task<int> CreateTableTransactionAsync();

    protected abstract Task<int> CreateTableTransactionFileAsync();
}
