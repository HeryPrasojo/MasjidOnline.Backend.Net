using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Core;

public class SqLiteCoreInitializer(
    CoreDataContext _dataContext,
    ICoreDefinition _coreDefinition) : CoreInitializer(_dataContext, _coreDefinition)
{
    protected override async Task<int> CreateTableCoreSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CoreSetting
            (
                Key TEXT PRIMARY KEY,
                Value TEXT NOT NULL
            )";

        return await _dataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableCaptchaQuestionAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CaptchaQuestion
            (
                Id INTEGER PRIMARY KEY,
                SessionId TEXT NOT NULL,
                Degree REAL NOT NULL,
                CreateDateTime TEXT NOT NULL
            )";

        return await _dataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableCaptchaAnswerAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CaptchaAnswer
            (
                Id INTEGER PRIMARY KEY,
                CaptchaQuestionId TEXT NOT NULL,
                Degree REAL NOT NULL,
                IsMatch REAL NOT NULL,
                CreateDateTime TEXT NOT NULL
            )";

        return await _dataContext.Database.ExecuteSqlAsync(sql);
    }
}
