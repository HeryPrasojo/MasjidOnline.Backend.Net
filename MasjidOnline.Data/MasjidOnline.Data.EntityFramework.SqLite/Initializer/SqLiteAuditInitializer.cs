using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteAuditInitializer(
    AuditDataContext _auditDataContext,
    IAuditDefinition _auditDefinition) : AuditInitializer(_auditDefinition)
{
    protected override async Task<int> CreateTableAuditSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE AuditSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL,
                Value TEXT NOT NULL
            )";

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTablePermissionLogAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE PermissionLog
            (
                PermissionLogId INTEGER PRIMARY KEY,
                SessionUserId INTEGER NOT NULL,
                DateTime TEXT NOT NULL,

                UserId INTEGER NOT NULL,
                UserInternalAdd INTEGER NOT NULL,
                TransactionInfaqRead INTEGER NOT NULL
            )";

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableUserLogAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserLog
            (
                UserLogId INTEGER PRIMARY KEY,
                SessionUserId INTEGER NOT NULL,
                DateTime TEXT NOT NULL,

                Id INTEGER NOT NULL,
                Name TEXT NOT NULL,
                Type INTEGER NOT NULL,
                EmailAddress TEXT NOT NULL,
                Password BLOB
            )";

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableUserEmailAddressLogAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserEmailAddressLog
            (
                UserEmailAddressLogId INTEGER PRIMARY KEY,
                SessionUserId INTEGER NOT NULL,
                DateTime TEXT NOT NULL,

                UserId INTEGER NOT NULL,
                EmailAddress TEXT NOT NULL
            )";

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }
}
