using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class VerificationInitializer(
    VerificationDataContext _verificationDataContext,
    IVerificationDefinition _verificationDefinition) : MasjidOnline.Data.Initializer.VerificationInitializer(_verificationDefinition)
{
    protected override async Task CreateTableVerificationSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE VerificationSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _verificationDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableVerificationCodeAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE VerificationCode
            (
                Id INTEGER PRIMARY KEY,
                Code BLOB NOT NULL,
                UserId INTEGER NOT NULL
                DateTime TEXT NOT NULL,
                Type INTEGER NOT NULL,
                ContactType INTEGER NOT NULL,
                Contact TEXT NOT NULL COLLATE NOCASE,
                UseDateTime TEXT
            )";

        await _verificationDataContext.Database.ExecuteSqlAsync(sql);
    }
}
