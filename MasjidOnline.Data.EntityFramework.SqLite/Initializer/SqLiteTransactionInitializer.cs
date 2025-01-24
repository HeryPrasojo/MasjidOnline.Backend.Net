using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteTransactionInitializer(
    TransactionDataContext _transactionDataContext,
    ITransactionDefinition _transactionDefinition) : TransactionInitializer(_transactionDefinition)
{
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

    protected override async Task<int> CreateTableTransactionAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE [Transaction]
            (
                Id INTEGER PRIMARY KEY,
                CreateDateTime TEXT NOT NULL,
                PaymentStatus INTEGER NOT NULL,
                Type INTEGER NOT NULL,
                UserType INTEGER NOT NULL,
                UserId INTEGER NULL,
                MunfiqName INTEGER NOT NULL,
                Amount REAL NOT NULL,
                PaymentType INTEGER NOT NULL,
                ManualBankTransferDateTime TEXT NOT NULL,
                ManualBankTransferNotes TEXT NOT NULL
            )";

        return await _transactionDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableTransactionFileAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE TransactionFile
            (
                Id INTEGER PRIMARY KEY,
                TransactionId INTEGER NOT NULL
            )";

        return await _transactionDataContext.Database.ExecuteSqlAsync(sql);
    }
}
