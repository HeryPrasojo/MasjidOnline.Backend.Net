using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Core;

public class SqLiteCoreInitializer(
    CoreDataContext _dataContext,
    ICoreDefinition _coreDefinition) : CoreInitializer(_dataContext, _coreDefinition)
{
    protected override async Task<int> CreateTableCoreSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CoreSetting
            (
                Key TEXT PRIMARY KEY,
                Value TEXT NOT NULL
            )";

        return await _dataContext.Database.ExecuteSqlAsync(sql);
    }
}
