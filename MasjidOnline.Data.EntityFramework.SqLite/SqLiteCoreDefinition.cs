using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public class SqLiteCoreDefinition(DataContext _dataContext) : CoreDefinition(_dataContext)
{
    protected override async Task<bool> CheckTableExistsAsync(string name)
    {
        FormattableString sql = $"SELECT COUNT(*) Value FROM sqlite_master WHERE type='table' AND name={name}";

        var queryable = _dataContext.Database.SqlQuery<long>(sql);

        var count = await queryable.SingleAsync();

        var exists = count == 1L;

        return exists;
    }

    protected override async Task<int> CreateTableSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Setting
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
