using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class AuditInitializer(
    AuditDataContext _auditDataContext,
    IAuditDefinition _auditDefinition) : MasjidOnline.Data.Initializer.AuditInitializer(_auditDefinition)
{
    protected override async Task CreateTableAuditSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE AuditSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableUserInternalPermissionLogAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserInternalPermissionLog
            (
                Id INTEGER PRIMARY KEY,
                LogDateTime TEXT NOT NULL,
                LogType TEXT NOT NULL,
                LogUserId INTEGER NOT NULL,

                UserId INTEGER NOT NULL,
                AccountancyExpenditureAdd INTEGER NOT NULL,
                AccountancyExpenditureApprove INTEGER NOT NULL,
                AccountancyExpenditureCancel INTEGER NOT NULL,
                InfaqExpireAdd INTEGER NOT NULL,
                InfaqExpireApprove INTEGER NOT NULL,
                InfaqExpireCancel INTEGER NOT NULL,
                InfaqSuccessAdd INTEGER NOT NULL,
                InfaqSuccessApprove INTEGER NOT NULL,
                InfaqSuccessCancel INTEGER NOT NULL,
                InfaqVoidAdd INTEGER NOT NULL,
                InfaqVoidApprove INTEGER NOT NULL,
                InfaqVoidCancel INTEGER NOT NULL,
                UserInternalAdd INTEGER NOT NULL,
                UserInternalApprove INTEGER NOT NULL,
                UserInternalCancel INTEGER NOT NULL
            )";

        await _auditDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX UserInternalPermissionLogDateTime ON UserInternalPermissionLog (LogDateTime)";

        await _auditDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX UserInternalPermissionLogUserId ON UserInternalPermissionLog (LogUserId)";

        await _auditDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX UserInternalPermissionUserId ON UserInternalPermissionLog (UserId)";

        await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableUserLogAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserLog
            (
                Id INTEGER PRIMARY KEY,
                LogDateTime TEXT NOT NULL,
                LogType TEXT NOT NULL,
                LogUserId INTEGER NOT NULL,

                UserId INTEGER NOT NULL,
                Status INTEGER NOT NULL,
                Type INTEGER,
                Password BLOB
            )";

        await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }
}
