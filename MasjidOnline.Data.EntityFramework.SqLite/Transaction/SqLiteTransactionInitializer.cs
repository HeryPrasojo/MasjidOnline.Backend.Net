using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Transaction;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Transaction;

public class SqLiteTransactionInitializer : TransactionInitializer
{
    public SqLiteTransactionInitializer(
        TransactionDataContext transactionDataContext,
        ITransactionDefinition transactionDefinition) : base(transactionDataContext, transactionDefinition)
    {
    }

    protected override async Task<int> CreateTableTransactionSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE TransactionSetting
            (
                Key TEXT PRIMARY KEY,
                Value TEXT NOT NULL
            )";

        return await _transactionDataContext.Database.ExecuteSqlAsync(sql);
    }
}
