using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteCoreInitializer(
    CoreDataContext _coreDataContext,
    ICoreData _coreData,
    ICoreDefinition _coreDefinition) : CoreInitializer(_coreData, _coreDefinition)
{
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
