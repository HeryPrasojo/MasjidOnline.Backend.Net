using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteEventInitializer(
    EventDataContext _eventDataContext,
    IEventData _eventData,
    IEventDefinition _eventDefinition) : EventInitializer(_eventData, _eventDefinition)
{
    protected override async Task<int> CreateTableErrorExceptionAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Exception
            (
                Id INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                Message TEXT NOT NULL,
                StackTrace TEXT
            )";

        return await _eventDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableEventSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE EventSetting
            (
                Key TEXT PRIMARY KEY,
                Value TEXT NOT NULL
            )";

        return await _eventDataContext.Database.ExecuteSqlAsync(sql);
    }
}
