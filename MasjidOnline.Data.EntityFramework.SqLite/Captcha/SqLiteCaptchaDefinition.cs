using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Captcha;

public class SqLiteCaptchaDefinition(CaptchaDataContext _captchaDataContext) : Definition, ICaptchaDefinition
{
    // todo move to new file SqLiteDefinition
    public override async Task<bool> CheckTableExistsAsync(string name)
    {
        FormattableString sql = $"SELECT COUNT(*) Value FROM sqlite_master WHERE type='table' AND name={name}";

        var queryable = _captchaDataContext.Database.SqlQuery<long>(sql);

        var count = await queryable.SingleAsync();

        var exists = count == 1L;

        return exists;
    }
}
