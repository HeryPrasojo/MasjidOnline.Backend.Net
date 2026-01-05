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
    protected override async Task CreateTableInternalUserAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE InternalUser
            (
                Id INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                UserId INTEGER NOT NULL,
                Status INTEGER NOT NULL,
                Description TEXT COLLATE NOCASE,
                AddUserId INTEGER NOT NULL,
                UpdateDateTime TEXT,
                UpdateUserId INTEGER
            )";

        await _userDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX InternalDateTime ON InternalUser (DateTime)";

        await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableUserAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE User
            (
                Id INTEGER PRIMARY KEY,
                Status INTEGER NOT NULL,
                Type INTEGER NOT NULL,
                Password BLOB
            )";

        await _userDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX UserStatus ON User (Status)";

        await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableUserEmailAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserEmail
            (
                Id INTEGER PRIMARY KEY,
                Address TEXT NOT NULL,
                UserId INTEGER NOT NULL
            )";

        await _userDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX UserEmailUserId ON UserEmail (UserId)";

        await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableUserDataAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserData
            (
                UserId INTEGER PRIMARY KEY,
                IsAcceptAgreement INTEGER NOT NULL,
                MainContactId INTEGER NOT NULL,
                MainContactType INTEGER NOT NULL,
                ApplicationCulture INTEGER
            )";

        await _userDataContext.Database.ExecuteSqlAsync(sql);
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
