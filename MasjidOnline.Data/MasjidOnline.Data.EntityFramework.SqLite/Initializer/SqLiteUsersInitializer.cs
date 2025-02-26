using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteUsersInitializer(
    UsersDataContext _userDataContext,
    IUsersDefinition _userDefinition) : UsersInitializer(_userDefinition)
{
    protected override async Task<int> CreateTableUserSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL,
                Value TEXT NOT NULL
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
                UserAddInternal INTEGER NOT NULL,
                InfaqSetPaymentStatusExpired INTEGER NOT NULL
            )";

        return await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableUserAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE User
            (
                Id INTEGER PRIMARY KEY,
                Name TEXT NOT NULL,
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
