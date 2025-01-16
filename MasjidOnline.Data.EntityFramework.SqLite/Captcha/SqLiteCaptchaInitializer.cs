using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Captcha;

public class SqLiteCaptchaInitializer(
    CaptchaDataContext _captchaDataContext,
    ICaptchaData _captchaData,
    ICaptchaDefinition _captchaDefinition) : CaptchaInitializer(_captchaData, _captchaDefinition)
{
    protected override async Task<int> CreateTableCaptchaSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CaptchaSetting
            (
                Key TEXT PRIMARY KEY,
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
                SessionId BLOB NOT NULL,
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
