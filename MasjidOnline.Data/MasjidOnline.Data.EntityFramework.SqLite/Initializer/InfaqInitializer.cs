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
    protected override async Task CreateTableExpireAsync()
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

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX ExpireDateTime ON Expire (DateTime)";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX ExpireStatus ON Expire (Status)";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableInfaqAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Infaq
            (
                Id INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                Status INTEGER NOT NULL,
                PaymentType INTEGER NOT NULL,
                UserId INTEGER NOT NULL,
                MunfiqName INTEGER NOT NULL,
                Amount REAL NOT NULL
            )";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX InfaqDateTime ON Infaq (DateTime)";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX InfaqPaymentStatus ON Infaq (Status)";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableInfaqFileAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE InfaqFile
            (
                Id INTEGER PRIMARY KEY,
                InfaqId INTEGER NOT NULL
            )";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX InfaqFileInfaqId ON InfaqFile (InfaqId)";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableInfaqManualAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE InfaqManual
            (
                InfaqId INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                Notes TEXT NOT NULL COLLATE NOCASE
            )";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableInfaqOnBehalfAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE InfaqOnBehalf
            (
                InfaqId INTEGER PRIMARY KEY,
                ByUserId INTEGER NOT NULL
            )";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableInfaqSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE InfaqSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableSuccessAsync()
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

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX SuccessDateTime ON Success (DateTime)";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX SuccessStatus ON Success (Status)";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableVoidAsync()
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

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX VoidDateTime ON Void (DateTime)";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX VoidStatus ON Void (Status)";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);
    }
}
