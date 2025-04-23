using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class PaymentInitializer(
    PaymentDataContext _databaseDataContext,
    IPaymentDefinition _databaseDefinition) : MasjidOnline.Data.Initializer.PaymentInitializer(_databaseDefinition)
{
    protected override async Task<int> CreateTablePaymentSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE PaymentSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        return await _databaseDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableManualRecommendationIdAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE ManualRecommendationId
            (
                Id INTEGER PRIMARY KEY,
                SessionId INTEGER NOT NULL,
                Used INTEGER NOT NULL
            )";

        return await _databaseDataContext.Database.ExecuteSqlAsync(sql);
    }
}
