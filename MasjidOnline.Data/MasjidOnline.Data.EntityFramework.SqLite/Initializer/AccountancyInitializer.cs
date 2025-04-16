using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class AccountancyInitializer(
    AccountancyDataContext _auditDataContext,
    IAccountancyDefinition _auditDefinition) : MasjidOnline.Data.Initializer.AccountancyInitializer(_auditDefinition)
{
    protected override async Task<int> CreateTableAccountancySettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE AccountancySetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableExpenditureAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Expenditure
            (
                Id INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                UserId INTEGER NOT NULL,
                Description TEXT NOT NULL COLLATE NOCASE,
                Amount REAL NOT NULL,
                Status INTEGER NOT NULL,
                StatusDescription TEXT COLLATE NOCASE,
                UpdateDateTime TEXT,
                UpdateUserId INTEGER
            )";

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }
}
