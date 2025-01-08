using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Captcha;

public class SqLiteCaptchaInitializer(
    CaptchaDataContext _captchaDataContext,
    ICaptchaDefinition _captchaDefinition) : CaptchaInitializer(_captchaDataContext, _captchaDefinition)
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
                SessionId TEXT NOT NULL,
                Degree REAL NOT NULL,
                CreateDateTime TEXT NOT NULL
            )";

        return await _captchaDataContext.Database.ExecuteSqlAsync(sql);
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

        return await _captchaDataContext.Database.ExecuteSqlAsync(sql);
    }
}
