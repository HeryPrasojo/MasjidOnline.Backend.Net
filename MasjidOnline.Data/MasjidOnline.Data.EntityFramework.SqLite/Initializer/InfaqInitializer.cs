using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class InfaqInitializer(
    InfaqDataContext _infaqDataContext,
    IInfaqsDefinition _infaqsDefinition) : MasjidOnline.Data.Initializer.InfaqInitializer(_infaqsDefinition)
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
                Status INTEGER NUT NULL,
                Description TEXT COLLATE NOCASE,
                UpdateDateTime TEXT,
                UpdateUserId INTEGER
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
                PaymentStatus INTEGER NOT NULL,
                PaymentType INTEGER NOT NULL,
                UserId INTEGER NOT NULL,
                MunfiqName INTEGER NOT NULL,
                Amount REAL NOT NULL
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

    protected override async Task<int> CreateTableInfaqManualAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE InfaqManual
            (
                InfaqId INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                Notes TEXT NOT NULL COLLATE NOCASE
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

    protected override async Task<int> CreateTableSuccessAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Success
            (
                Id INTEGER PRIMARY KEY,
                InfaqId INTEGER NOT NULL,
                DateTime TEXT NOT NULL,
                UserId INTEGER NUT NULL,
                Status INTEGER NUT NULL,
                Description TEXT COLLATE NOCASE,
                UpdateDateTime TEXT,
                UpdateUserId INTEGER
            )";

        return await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableVoidAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Void
            (
                Id INTEGER PRIMARY KEY,
                InfaqId INTEGER NOT NULL,
                DateTime TEXT NOT NULL,
                UserId INTEGER NUT NULL,
                Status INTEGER NUT NULL,
                Description TEXT COLLATE NOCASE,
                UpdateDateTime TEXT,
                UpdateUserId INTEGER
            )";

        return await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }
}
