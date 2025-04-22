using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Database;

namespace MasjidOnline.Data.Initializer;

public abstract class DatabaseInitializer(IDatabaseDefinition _databaseDefinition) : IDatabaseInitializer
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _databaseDefinition.CheckTableExistsAsync(nameof(DatabaseSetting));

        if (!settingTableExists)
        {
            await CreateTableDatabaseSettingAsync();
            await CreateTableTableAsync();


            var databaseSetting = new DatabaseSetting
            {
                Id = (int)DatabaseSettingId.DatabaseVersion,
                Description = nameof(DatabaseSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Database.DatabaseSetting.AddAsync(databaseSetting);

            await data.Database.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableDatabaseSettingAsync();
    protected abstract Task<int> CreateTableTableAsync();
}
