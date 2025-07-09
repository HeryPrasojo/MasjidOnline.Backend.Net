using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class PersonInitializer(
    PersonDataContext _personDataContext,
    IPersonDefinition _personDefinition) : MasjidOnline.Data.Initializer.PersonInitializer(_personDefinition)
{
    protected override async Task CreateTablePersonSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE PersonSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _personDataContext.Database.ExecuteSqlAsync(sql);
    }
}
