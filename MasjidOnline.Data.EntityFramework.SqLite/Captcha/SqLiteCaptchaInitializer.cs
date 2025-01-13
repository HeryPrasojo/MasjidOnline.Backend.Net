using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Captcha;

public class SqLiteCaptchaInitializer : CaptchaInitializer
{
    public SqLiteCaptchaInitializer(
        CaptchaDataContext captchaDataContext,
        ICaptchaDefinition captchaDefinition) : base(captchaDataContext, captchaDefinition)
    {
    }

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
