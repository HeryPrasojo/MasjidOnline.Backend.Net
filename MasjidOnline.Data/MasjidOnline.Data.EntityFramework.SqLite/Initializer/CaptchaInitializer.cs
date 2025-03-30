using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class CaptchaInitializer(
    CaptchaDataContext _captchaDataContext,
    ICaptchaDefinition _captchaDefinition) : MasjidOnline.Data.Initializer.CaptchaInitializer(_captchaDefinition)
{
    protected override async Task<int> CreateTableCaptchaSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CaptchaSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        return await _captchaDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableCaptchaAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Captcha
            (
                Id INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL,
                SessionId INTEGER NOT NULL,
                UpdateDateTime TEXT,
                IsMatched INTEGER,
                QuestionFloat REAL NOT NULL,
                AnswerFloat REAL
            )";

        return await _captchaDataContext.Database.ExecuteSqlAsync(sql);
    }
}
