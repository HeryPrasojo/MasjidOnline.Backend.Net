using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class AccountancyInitializer(
    AccountancyDataContext _auditDataContext,
    IAccountancyDefinition _auditDefinition) : MasjidOnline.Data.Initializer.AccountancyInitializer(_auditDefinition)
{
    protected override async Task<int> CreateTableAccountancySettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE AccountancySetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }
    // undone
    protected override async Task<int> CreateTableExpenditureAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Expenditure
            (
                Id INTEGER PRIMARY KEY,
                LogDateTime TEXT NOT NULL,
                LogType TEXT NOT NULL,
                LogUserId INTEGER NOT NULL,

                UserId INTEGER NOT NULL,
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

        return await _auditDataContext.Database.ExecuteSqlAsync(sql);
    }
}
