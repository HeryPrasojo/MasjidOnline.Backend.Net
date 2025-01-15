using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Core;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Core;

public class SqLiteCoreInitializer : CoreInitializer
{
    private readonly CoreDataContext _coreDataContext;

    public SqLiteCoreInitializer(
        CoreDataContext coreDataContext,
        ICoreData coreData,
        ICoreDefinition coreDefinition) : base(coreData, coreDefinition)
    {
        _coreDataContext = coreDataContext;
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
