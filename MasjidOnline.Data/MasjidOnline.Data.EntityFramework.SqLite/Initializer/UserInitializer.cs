using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class UserInitializer(
    UserDataContext _userDataContext,
    IUsersDefinition _userDefinition) : MasjidOnline.Data.Initializer.UserInitializer(_userDefinition)
{
    protected override async Task<int> CreateTableInternalAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Internal
            (
                Id INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                EmailAddress TEXT NOT NULL COLLATE NOCASE,
                UserId INTEGER NOT NULL,
                Status INTEGER NOT NULL,
                Description TEXT COLLATE NOCASE,
                UpdateDateTime TEXT,
                UpdateUserId INTEGER
            )";

        return await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTablePasswordCodeAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE PasswordCode
            (
                Code BLOB PRIMARY KEY,
                DateTime TEXT NOT NULL,
                UserId INTEGER NOT NULL,
                UseDateTime TEXT
            )";

        return await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableUserAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE User
            (
                Id INTEGER PRIMARY KEY,
                Status INTEGER NOT NULL,
                Type INTEGER NOT NULL,
                Password BLOB
            )";

        return await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableUserEmailAddressAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserEmailAddress
            (
                EmailAddress TEXT PRIMARY KEY,
                UserId INTEGER NOT NULL
            )";

        return await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableUserPreferenceAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserPreference
            (
                UserId INTEGER PRIMARY KEY,
                ApplicationCulture INTEGER NOT NULL
            )";

        return await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableUserSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        return await _userDataContext.Database.ExecuteSqlAsync(sql);
    }
}
