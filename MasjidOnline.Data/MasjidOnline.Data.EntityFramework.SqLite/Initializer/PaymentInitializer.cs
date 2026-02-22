using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class PaymentInitializer(
    PaymentDataContext _paymentDataContext,
    IPaymentDefinition _paymentDefinition) : MasjidOnline.Data.Initializer.PaymentInitializer(_paymentDefinition)
{
    protected override async Task CreateTablePaymentSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE PaymentSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _paymentDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableManualRecommendationIdAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE ManualRecommendationId
            (
                Id INTEGER PRIMARY KEY,
                SessionId INTEGER NOT NULL,
                Used INTEGER NOT NULL
            )";

        await _paymentDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX ManualRecommendationIdSessionId ON ManualRecommendationId (SessionId)";

        await _paymentDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTablePaymentAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Payment
            (
                Id INTEGER PRIMARY KEY,
                PaymentType INTEGER NOT NULL,
                DateTime TEXT NOT NULL,
                Status INTEGER NOT NULL,
                ManualNotes TEXT,
                UpdateDateTime TEXT,
                UpdateNotes TEXT
            )";

        await _paymentDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTablePaymentFileAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE PaymentFile
            (
                Id INTEGER PRIMARY KEY,
                PaymentId INTEGER NOT NULL
            )";

        await _paymentDataContext.Database.ExecuteSqlAsync(sql);
    }
}
