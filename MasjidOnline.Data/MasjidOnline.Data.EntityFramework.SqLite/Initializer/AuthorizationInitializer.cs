using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class AuthorizationInitializer(
    AuthorizationDataContext _authorizationDataContext,
    IAuthorizationDefinition _authorizationDefinition) : MasjidOnline.Data.Initializer.AuthorizationInitializer(_authorizationDefinition)
{
    protected override async Task<int> CreateTableAuthorizationSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE AuthorizationSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        return await _authorizationDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableUserInternalPermissionAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE UserInternalPermission
            (
                UserId INTEGER PRIMARY KEY,

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

        return await _authorizationDataContext.Database.ExecuteSqlAsync(sql);
    }
}
