using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteAuditInitializer(
    AuditDataContext _auditDataContext,
IAuditData _auditData,
    IAuditDefinition _auditDefinition) : AuditInitializer(_auditData, _auditDefinition)
{
    protected override async Task<int> CreateTableCaptchaSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE AuditSetting
            (
                Key TEXT PRIMARY KEY,
                Value TEXT NOT NULL
            )";

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableCaptchaQuestionAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserLog
            (
                UserLogId INTEGER PRIMARY KEY,

                Id INTEGER NOT NULL,
                Name TEXT NOT NULL,
                UserType INTEGER NOT NULL,
                EmailAddressId INTEGER NOT NULL,

                SessionUserId INTEGER NOT NULL,
                DateTime TEXT NOT NULL
            )";

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableCaptchaAnswerAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserEmailAddressLog
            (
                UserEmailAddressLogId INTEGER PRIMARY KEY,

                Id INTEGER NOT NULL,
                UserId INTEGER NOT NULL,
                EmailAddress TEXT NOT NULL,
                Disabled INTEGER NOT NULL

                SessionUserId INTEGER NOT NULL,
                DateTime TEXT NOT NULL
            )";

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }
}
