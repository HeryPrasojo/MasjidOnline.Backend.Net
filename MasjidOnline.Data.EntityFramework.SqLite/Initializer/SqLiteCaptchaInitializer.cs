using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteCaptchaInitializer(
    CaptchaDataContext _captchaDataContext,
    ICaptchaDefinition _captchaDefinition) : CaptchaInitializer(_captchaDefinition)
{
    protected override async Task<int> CreateTableCaptchaSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CaptchaSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL,
                Value TEXT NOT NULL
            )";

        return await _captchaDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableCaptchaQuestionAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CaptchaQuestion
            (
                Id INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                SessionId INTEGER NOT NULL,
                Degree REAL NOT NULL
            )";

        return await _captchaDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableCaptchaAnswerAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CaptchaAnswer
            (
                Id INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                CaptchaQuestionId INTEGER NOT NULL,
                Degree REAL NOT NULL,
                IsMatch INTEGER NOT NULL
            )";

        return await _captchaDataContext.Database.ExecuteSqlAsync(sql);
    }
}
