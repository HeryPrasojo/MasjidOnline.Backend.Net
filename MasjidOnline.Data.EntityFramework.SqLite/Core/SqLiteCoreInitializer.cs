using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Core;

public class SqLiteCoreInitializer : CoreInitializer
{
    public SqLiteCoreInitializer(
        CoreDataContext coreDataContext,
        ICoreDefinition coreDefinition) : base(coreDataContext, coreDefinition)
    {
    }

    protected override async Task<int> CreateTableCoreSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CoreSetting
            (
                Key TEXT PRIMARY KEY,
                Value TEXT NOT NULL
            )";

        return await _coreDataContext.Database.ExecuteSqlAsync(sql);
    }
}
