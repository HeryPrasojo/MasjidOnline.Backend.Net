using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteInfaqsInitializer(
    InfaqsDataContext _infaqsDataContext,
    IInfaqsDefinition _infaqsDefinition) : TransactionInitializer(_infaqsDefinition)
{
    protected override async Task<int> CreateTableInfaqSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE InfaqSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL,
                Value TEXT NOT NULL
            )";

        return await _infaqsDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableInfaqAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Infaq
            (
                Id INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                Type INTEGER NOT NULL,
                PaymentStatus INTEGER NOT NULL,
                PaymentType INTEGER NOT NULL,
                UserId INTEGER NULL,
                MunfiqName INTEGER NOT NULL,
                Amount REAL NOT NULL,
                ManualBankTransferDateTime TEXT NOT NULL,
                ManualBankTransferNotes TEXT NOT NULL
            )";

        return await _infaqsDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableInfaqFileAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE InfaqFile
            (
                Id INTEGER PRIMARY KEY,
                InfaqId INTEGER NOT NULL
            )";

        return await _infaqsDataContext.Database.ExecuteSqlAsync(sql);
    }
}
