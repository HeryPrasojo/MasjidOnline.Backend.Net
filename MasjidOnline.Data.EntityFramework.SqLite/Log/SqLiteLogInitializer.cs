using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Log;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Log;

public class SqLiteLogInitializer : LogInitializer
{
    public SqLiteLogInitializer(
        LogDataContext logDataContext,
        ILogDefinition logDefinition) : base(logDataContext, logDefinition)
    {
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
