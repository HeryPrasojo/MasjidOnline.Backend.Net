using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteLogInitializer(
    LogDataContext _logDataContext,
    ILogData _logData,
    ILogDefinition _logDefinition) : LogInitializer(_logData, _logDefinition)
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

        return await _logDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableLogSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE LogSetting
            (
                Key TEXT PRIMARY KEY,
                Value TEXT NOT NULL
            )";

        return await _logDataContext.Database.ExecuteSqlAsync(sql);
    }
}
