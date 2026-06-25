using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class DonationInitializer(
    DonationDataContext _DonationDataContext,
    IDonationsDefinition _donationsDefinition) : MasjidOnline.Data.Initializer.DonationInitializer(_donationsDefinition)
{
    protected override async Task CreateTableDonationAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Donation
            (
                Id INTEGER PRIMARY KEY,
                ReceiverType INTEGER NOT NULL,
                ReceiverId INTEGER,
                DateTime TEXT NOT NULL,
                UserId INTEGER NOT NULL,
                MunfiqName INTEGER NOT NULL,
                Amount REAL NOT NULL,
                PaymentId INTEGER NOT NULL,
                PaymentType INTEGER NOT NULL,
                Status INTEGER NOT NULL
            )";

        await _DonationDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableDonationSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE DonationSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _DonationDataContext.Database.ExecuteSqlAsync(sql);
    }
}


