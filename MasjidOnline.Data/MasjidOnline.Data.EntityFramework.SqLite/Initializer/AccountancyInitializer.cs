using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class AccountancyInitializer(
    AccountancyDataContext _accountancyDataContext,
    IAccountancyDefinition _accountancyDefinition) : MasjidOnline.Data.Initializer.AccountancyInitializer(_accountancyDefinition)
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

        return await _accountancyDataContext.Database.ExecuteSqlAsync(sql);
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

        return await _accountancyDataContext.Database.ExecuteSqlAsync(sql);
    }
}
