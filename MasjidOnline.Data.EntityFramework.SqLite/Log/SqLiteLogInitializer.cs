using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Log;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Log;

public class SqLiteLogInitializer : LogInitializer
{
    private readonly LogDataContext _logDataContext;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>")]
    public SqLiteLogInitializer(
        LogDataContext logDataContext,
        ILogDefinition logDefinition) : base(logDataContext, logDefinition)
    {
        _logDataContext = logDataContext;
    }

    protected override async Task<int> CreateTableErrorExceptionAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE ErrorException
            (
                Key TEXT PRIMARY KEY,
                Value TEXT NOT NULL
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
