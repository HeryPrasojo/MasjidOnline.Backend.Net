using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteUsersInitializer(
    UserDataContext _userDataContext,
    IUsersDefinition _userDefinition) : UserInitializer(_userDefinition)
{
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

    protected override async Task<int> CreateTablePermissionAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Permission
            (
                UserId INTEGER PRIMARY KEY,
                UserInternalAdd INTEGER NOT NULL,
                UserInternalCancel INTEGER NOT NULL,
                InfaqExpiredAdd INTEGER NOT NULL
            )";

        return await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableUserAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE User
            (
                Id INTEGER PRIMARY KEY,
                Name TEXT NOT NULL COLLATE NOCASE,
                Type INTEGER NOT NULL,
                EmailAddress TEXT NOT NULL,
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
}
