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
    protected override async Task CreateTableInfaqAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Infaq
            (
                Id INTEGER PRIMARY KEY,
                ReceiverType INTEGER NOT NULL,
                ReceiverId INTEGER NOT NULL,
                DateTime TEXT NOT NULL,
                UserId INTEGER NOT NULL,
                ByUserId INTEGER NOT NULL,
                MunfiqName INTEGER NOT NULL,
                Amount REAL NOT NULL,
                PaymentId INTEGER NOT NULL,
                PaymentType INTEGER NOT NULL,
                Status INTEGER NOT NULL
            )";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX InfaqDateTime ON Infaq (DateTime)";

        await _infaqDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX InfaqPaymentStatus ON Infaq (Status)";

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
}
