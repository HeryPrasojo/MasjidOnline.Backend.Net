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
                ContactUserId INTEGER NOT NULL,
                NickName TEXT NOT NULL COLLATE NOCASE
            )";

        await _contactListDataContext.Database.ExecuteSqlAsync(sql);
    }
}
