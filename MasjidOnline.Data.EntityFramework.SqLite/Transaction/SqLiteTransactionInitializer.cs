using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Transactions;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Transaction;

public class SqLiteTransactionInitializer : TransactionInitializer
{
    private readonly TransactionDataContext _transactionDataContext;

    public SqLiteTransactionInitializer(
        TransactionDataContext transactionDataContext,
        ITransactionData transactionData,
        ITransactionDefinition transactionDefinition) : base(transactionData, transactionDefinition)
    {
        _transactionDataContext = transactionDataContext;
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
