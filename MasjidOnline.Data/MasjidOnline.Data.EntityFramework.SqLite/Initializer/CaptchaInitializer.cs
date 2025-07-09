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
    protected override async Task CreateTableCaptchaSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CaptchaSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _captchaDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTablePassAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Pass
            (
                SessionId INTEGER PRIMARY KEY,
                DateTime TEXT NOT NULL
            )";

        await _captchaDataContext.Database.ExecuteSqlAsync(sql);
    }
}
