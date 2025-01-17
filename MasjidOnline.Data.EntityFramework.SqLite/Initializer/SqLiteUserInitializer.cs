using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteUserInitializer(
    UserDataContext _userDataContext,
    IUserData _userData,
    IUserDefinition _userDefinition) : UserInitializer(_userData, _userDefinition)
{
    protected override async Task<int> CreateTableUserSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserSetting
            (
                Key TEXT PRIMARY KEY,
                Value TEXT NOT NULL
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
                UserType INTEGER NOT NULL,
                EmailAddressId INTEGER NOT NULL
            )";

        return await _userDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableUserEmailAddressAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserEmailAddress
            (
                Id INTEGER PRIMARY KEY,
                UserId INTEGER NOT NULL,
                EmailAddress TEXT NOT NULL,
                Disabled INTEGER NOT NULL
            )";

        return await _userDataContext.Database.ExecuteSqlAsync(sql);
    }
}
