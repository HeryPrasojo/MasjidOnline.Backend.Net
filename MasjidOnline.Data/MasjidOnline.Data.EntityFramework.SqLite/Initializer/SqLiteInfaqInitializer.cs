using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteInfaqInitializer(
    InfaqDataContext _infaqDataContext,
    IInfaqsDefinition _infaqsDefinition) : InfaqInitializer(_infaqsDefinition)
{
    protected override async Task<int> CreateTableExpireAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Expire
            (
                Id INTEGER PRIMARY KEY,
                InfaqId INTEGER NOT NULL,
                DateTime TEXT NOT NULL,
                UserId INTEGER NUT NULL,
                Status INTEGER NUT NULL
                UpdateDateTime TEXT,
                UpdateUserId INTEGER,
            )";

        return await _infaqDataContext.Database.ExecuteSqlAsync(sql);
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
                UserId INTEGER NOT NULL,
                MunfiqName INTEGER NOT NULL,
                Amount REAL NOT NULL,
                ManualBankTransferDateTime TEXT NOT NULL,
                ManualBankTransferNotes TEXT NOT NULL COLLATE NOCASE
            )";

        return await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableInfaqFileAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE InfaqFile
            (
                Id INTEGER PRIMARY KEY,
                InfaqId INTEGER NOT NULL
            )";

        return await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableInfaqSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE InfaqSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        return await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }
}
