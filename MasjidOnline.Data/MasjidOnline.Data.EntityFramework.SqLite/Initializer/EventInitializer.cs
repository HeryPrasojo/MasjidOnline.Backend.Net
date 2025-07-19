using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class EventInitializer(
    EventDataContext _eventDataContext,
    IEventDefinition _eventDefinition) : MasjidOnline.Data.Initializer.EventInitializer(_eventDefinition)
{
    protected override async Task CreateTableErrorExceptionAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Exception
            (
                Id INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                Type TEXT NOT NULL,
                Message TEXT NOT NULL COLLATE NOCASE,
                StackTrace TEXT COLLATE NOCASE,
                InnerExceptionId INTEGER
            )";

        await _eventDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX ExceptionDateTime ON Exception (DateTime)";

        await _eventDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableEventSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE EventSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _eventDataContext.Database.ExecuteSqlAsync(sql);
    }
}
