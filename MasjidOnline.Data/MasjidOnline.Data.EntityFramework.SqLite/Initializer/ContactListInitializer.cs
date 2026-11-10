using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class ContactListInitializer(
    ContactListDataContext _contactListDataContext,
    IContactListDefinition _contactListDefinition) : MasjidOnline.Data.Initializer.ContactListInitializer(_contactListDefinition)
{
    protected override async Task CreateTableContactListSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE ContactListSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _contactListDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableContactListAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE ContactList
            (
                Id INTEGER PRIMARY KEY,
                UserId INTEGER NOT NULL,
                DateTime TEXT NOT NULL,
                ContactUserId INTEGER NOT NULL,
                NickName TEXT NOT NULL COLLATE NOCASE
            )";

        await _contactListDataContext.Database.ExecuteSqlAsync(sql);

        sql = $@"CREATE INDEX ContactListDateTime ON ContactList (DateTime)";

        await _contactListDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableContactListRequestAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE ContactListRequest
            (
                Id INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                UserId INTEGER NOT NULL,
                NickName TEXT NOT NULL COLLATE NOCASE,
                ContactUserId INTEGER NOT NULL,
                ContactType INTEGER NOT NULL,
                Contact TEXT NOT NULL COLLATE NOCASE,
                Status INTEGER NOT NULL,
                UpdateDateTime TEXT
            )";

        await _contactListDataContext.Database.ExecuteSqlAsync(sql);

        sql = $@"CREATE INDEX ContactListRequestDateTime ON ContactListRequest (DateTime)";

        await _contactListDataContext.Database.ExecuteSqlAsync(sql);
    }
}
