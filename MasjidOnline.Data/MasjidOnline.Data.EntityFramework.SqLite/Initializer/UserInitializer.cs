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

    // undone
    //protected override async Task CreateTableRegisterAsync()
    //{
    //    FormattableString sql = @$"
    //        CREATE TABLE Register
    //        (
    //            Id INTEGER PRIMARY KEY,
    //            DateTime TEXT NOT NULL,
    //            With INTEGER NOT NULL,
    //            WithId TEXT NOT NULL,
    //            Code TEXT NOT NULL,
    //            UseDateTime TEXT
    //        )";

    //    await _userDataContext.Database.ExecuteSqlAsync(sql);


    //    sql = $@"CREATE INDEX PasswordCodeDateTime ON PasswordCode (DateTime)";

    //    await _userDataContext.Database.ExecuteSqlAsync(sql);
    //}

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

    protected override async Task CreateTableUserEmailAddressAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserEmailAddress
            (
                EmailAddress TEXT PRIMARY KEY,
                UserId INTEGER NOT NULL
            )";

        await _userDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX UserEmailAddressUserId ON UserEmailAddress (UserId)";

        await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableUserPreferenceAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserPreference
            (
                UserId INTEGER PRIMARY KEY,
                ApplicationCulture INTEGER NOT NULL
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
